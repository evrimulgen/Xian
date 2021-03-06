#region License (non-CC)

// This software is licensed under the Microsoft Limited Public License,
// the terms of which are listed as follows.
//
// 1. Definitions
//    The terms "reproduce," "reproduction," "derivative works," and
//    "distribution" have the same meaning here as under U.S. copyright law.
//    * A "contribution" is the original software, or any additions or changes to
//      the software.
//    * A "contributor" is any person that distributes its contribution under this
//      license.
//    * "Licensed patents" are a contributor's patent claims that read directly on
//      its contribution.
//
// 2. Grant of Rights
//    (A) Copyright Grant - Subject to the terms of this license, including the
//        license conditions and limitations in section 3, each contributor grants
//        you a non-exclusive, worldwide, royalty-free copyright license to
//        reproduce its contribution, prepare derivative works of its contribution,
//        and distribute its contribution or any derivative works that you create.
//    (B) Patent Grant - Subject to the terms of this license, including the
//        license conditions and limitations in section 3, each contributor grants
//        you a non-exclusive, worldwide, royalty-free license under its licensed
//        patents to make, have made, use, sell, offer for sale, import, and/or
//        otherwise dispose of its contribution in the software or derivative works
//        of the contribution in the software.
//
// 3. Conditions and Limitations
//    (A) No Trademark License - This license does not grant you rights to use any
//        contributors' name, logo, or trademarks.
//    (B) If you bring a patent claim against any contributor over patents that you
//        claim are infringed by the software, your patent license from such
//        contributor to the software ends automatically.
//    (C) If you distribute any portion of the software, you must retain all
//        copyright, patent, trademark, and attribution notices that are present in
//        the software.
//    (D) If you distribute any portion of the software in source code form, you
//        may do so only under this license by including a complete copy of this
//        license with your distribution. If you distribute any portion of the
//        software in compiled or object code form, you may only do so under a
//        license that complies with this license.
//    (E) The software is licensed "as-is." You bear the risk of using it. The
//        contributors give no express warranties, guarantees or conditions. You
//        may have additional consumer rights under your local laws which this
//        license cannot change. To the extent permitted under your local laws,
//        the contributors exclude the implied warranties of merchantability,
//        fitness for a particular purpose and non-infringement.
//    (F) Platform Limitation - The licenses granted in sections 2(A) & 2(B) extend
//        only to the software or derivative works that you create that run on a
//        Microsoft Windows operating system product.

#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Enterprise.Core
{
    /// <summary>
    /// Controls the type of peristence context that <see cref="PersistenceScope"/> creates.
    /// </summary>
    public enum PersistenceContextType
    {
        Read,
        Update
    }

    /// <summary>
    /// Controls whether the scope will attempt to inherit an existing persistence context, or create a new one
    /// </summary>
    public enum PersistenceScopeOption
    {
        /// <summary>
        /// Inherits an existing context, or creates a new context if no context exists
        /// </summary>
        Required,

        /// <summary>
        /// Creates a new context
        /// </summary>
        RequiresNew
    }


    

    /// <summary>
    /// Used primarily by the AOP advice classes to manage the scoping of persistence contexts around service method calls.
    /// Can also be used by application code for the same purpose.
    /// 
    /// Semantics of use are similar to the .NET framework <see cref="System.Transactions.TransactionScope"/> class.
    /// </summary>
    // Taken and modified from the following MSDN article by Stephen Toub:
    // http://msdn.microsoft.com/msdnmag/issues/06/09/NETMatters/default.aspx
    public class PersistenceScope : IDisposable
	{
		#region Vote enum

		enum Vote
        {
            Undecided,
            Abort,
            Complete
		}

		#endregion

		#region Private members

		[ThreadStatic]
		private static PersistenceScope _head;

		private bool _disposed;
        private IPersistenceContext _context;
        private readonly PersistenceScope _parent;
        private Vote _vote;

		#endregion

		#region Constructors

		/// <summary>
        /// Creates a new persistence scope for the specified context.  The scope assumes ownership of the context
        /// and closes it when the scope terminates.
        /// </summary>
        /// <param name="context"></param>
        public PersistenceScope(IPersistenceContext context)
        {
            _context = context;
            _parent = _head;
            _head = this;
        }


        /// <summary>
        /// Creates a new persistence scope for the specified context type, inheriting an existing context if possible.
        /// </summary>
        /// <remarks>
        /// If there is no parent scope, a new context of the specified type will be opened.
        /// If there is a parent scope holding a context of the correct type, that context will be inherited.
        /// If a new context is opened, the scope owns the context, and closes it when the scope terminates.
        /// If a context was inherited, the scope does not own the context, and takes no action on it when the scope terminates.
        /// If an update context is requested and while a parent scope is holding a read context, an exception will be thrown.
        /// If a read context is requested while a parent scope is holding an update context, the update context will be inherited.
        /// </remarks>
        /// <param name="contextType"></param>
        public PersistenceScope(PersistenceContextType contextType)
            :this(InheritOrCreateContext(contextType, PersistenceScopeOption.Required))
        {
        }

        /// <summary>
        /// Creates a new persistence scope for the specified context type, using the specified option to determine
        /// whether to create a new persistence context, or attempt to inherit an existing context.
        /// </summary>
        /// <remarks>
        /// If there is no parent scope, or <see cref = "PersistenceScopeOption.RequiresNew"/> was specified, 
        /// a new context of the specified type will be opened.  Otherwise, 
        /// if there is a parent scope holding a context of the correct type, that context will be inherited.
        /// If a new context is opened, the scope owns the context, and closes it when the scope terminates.
        /// If a context was inherited, the scope does not own the context, and takes no action on it when the scope terminates.
        /// If an update context is requested and while a parent scope is holding a read context, an exception will be thrown.
        /// If a read context is requested while a parent scope is holding an update context, the update context will be inherited.
        /// </remarks>
        /// <param name="contextType"></param>
        /// <param name="scopeOption"></param>
        public PersistenceScope(PersistenceContextType contextType, PersistenceScopeOption scopeOption)
            : this(InheritOrCreateContext(contextType, scopeOption))
        {
		}

		#endregion

		#region Public API

		/// <summary>
		/// Gets the <see cref="IPersistenceContext"/> associated with the current <see cref="PersistenceScope"/>,
		/// or null if there is no current scope.
		/// </summary>
		public static IPersistenceContext CurrentContext
		{
			get { return _head != null ? _head._context : null; }
		}

		/// <summary>
		/// Gets the current <see cref="PersistenceScope"/>, or null if no scope has been established.
		/// </summary>
		public static PersistenceScope Current
		{
			get { return _head; }
		}

		/// <summary>
		/// Gets the <see cref="IPersistenceContext"/> associated with this scope.
		/// </summary>
		public IPersistenceContext Context
		{
			get { return _context; }
		}

		/// <summary>
		/// Marks this scope as complete, meaning the scope will vote to commit any changes made in
		/// the associated persistence context.
		/// </summary>
		public void Complete()
		{
			if (_vote == Vote.Undecided)
			{

				_vote = Vote.Complete;
			}
			else
			{
				// an Abort vote cannot be changed
			}
		}

		/// <summary>
		/// Disposes of this scope.
		/// </summary>
		/// <remarks>
		/// If this scope is associated with an update context and is the owner of that context,
		/// then disposal will commit or rollback the changes made in the update context, depending
		/// on whether this scope was marked Completed.  If <see cref="Complete"/> was called on this scope,
		/// then disposal will attempt to commit the update context, otherwise it will simply dispose it,
		/// which is effectively a rollback.
		/// </remarks>
		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;

				if (this != _head)
					throw new InvalidOperationException("Disposed out of order.");

				try
				{
					if (OwnsContext)
					{
						CloseContext();
					}
					else
					{
						// if the vote is still "undecided", treat it as an abort
						if (_vote == Vote.Undecided)
						{
							_vote = Vote.Abort;

							// we have an inherited context, so we need to propagate "aborts" up to the parent
							_parent._vote = Vote.Abort;
						}
					}
				}
				finally
				{
					// if CloseContext fails, we are still disposing of this scope, so we set the head
					// to point to the parent
					_head = _parent;
				}
			}
		}

		#endregion

		#region Helpers

		private static IPersistenceContext InheritOrCreateContext(PersistenceContextType contextType, PersistenceScopeOption scopeOption)
        {
            if (scopeOption == PersistenceScopeOption.RequiresNew)
            {
                // need to create a new context
                return (contextType == PersistenceContextType.Update) ?
                    (IPersistenceContext)PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush) :
                    (IPersistenceContext)PersistentStoreRegistry.GetDefaultStore().OpenReadContext();
            }
            else 
            {
                // create a context if one doesn't exist, or attempt to inherit the existing one

                if (contextType == PersistenceContextType.Update)
                {
                    // if no current context, create an update context
                    if (PersistenceScope.CurrentContext == null)
                        return PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush);

                    // if the current context is an update context, inherit
                    if (PersistenceScope.CurrentContext is IUpdateContext)
                        return PersistenceScope.CurrentContext;

                    // can't ask for an update context when current context is a read context
                    throw new InvalidOperationException(SR.ExceptionIncompatiblePersistenceContext);
                }
                else
                {
                    // if no current context, create a read context
                    if (PersistenceScope.CurrentContext == null)
                        return PersistentStoreRegistry.GetDefaultStore().OpenReadContext();

                    // otherwise return the current context, regardless of its type
                    // (read operations are allowed to execute in an update context)
                    return PersistenceScope.CurrentContext;
                }
            }
        }


        /// <summary>
        /// This scope owns the context if there is no parent scope, or if there is a parent scope
        /// that holds a different context.
        /// </summary>
        private bool OwnsContext
        {
            get { return _parent == null || _parent._context != this._context; }
        }

        private void CloseContext()
        {
            System.Diagnostics.Debug.Assert(this.OwnsContext);

            try 
	        {	
                // if it is an update context and the vote is "complete", then try to commit
                IUpdateContext uctx = _context as IUpdateContext;
                if (null != uctx && _vote == Vote.Complete)
                {
                    uctx.Commit();
                }
	        }
	        finally
	        {
                // in any case, we need to dispose of the context here
                _context.Dispose();
                _context = null;
	        }
		}

		#endregion
	}
}
