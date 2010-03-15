﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Desktop
{
    /// <summary>
	/// Defines an extension point for views onto the <see cref="NavigatorComponentContainer"/>.
    /// </summary>
	public sealed class NavigatorComponentContainerViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// An application component that acts as a container for other application components.
    /// </summary>
    /// <remarks>
    /// The child components are treated as "pages", where each page is a node in a tree.
    /// Only one page is displayed at a time, however, a navigation tree is provided on the side
    /// to aid the user in navigating the set of pages.
	/// </remarks>
    [AssociateView(typeof(NavigatorComponentContainerViewExtensionPoint))]
    public class NavigatorComponentContainer : PagedComponentContainer<NavigatorPage>
    {
        private bool _forwardEnabled;
        private event EventHandler _forwardEnabledChanged;

        private bool _backEnabled;
        private event EventHandler _backEnabledChanged;

        private bool _acceptEnabled;
        private event EventHandler _acceptEnabledChanged;

    	private readonly bool _showApply;
		private bool _applyEnabled;
		private event EventHandler _applyEnabledChanged;

    	private bool _startFullyExpanded;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NavigatorComponentContainer()
			: this(false)
        {
        }

		/// <summary>
		/// Protected constructor.
		/// </summary>
		/// <param name="showApply">Indicates whether or not to show an apply button.</param>
		protected NavigatorComponentContainer(bool showApply)
		{
			_showApply = showApply;
		}
		
		#region Presentation Model

		/// <summary>
		/// Gets whether the components will show the tree pane.
		/// </summary>
    	public virtual bool ShowTree
    	{
    		get { return true; }
    	}

		/// <summary>
		/// Gets a value indicating whether the components starts with the entire tree expanded.
		/// </summary>
		/// <remarks>
		/// Setting this value has no effect after the component has started.
		/// </remarks>
    	public bool StartFullyExpanded
    	{
			get { return _startFullyExpanded; }
			set { _startFullyExpanded = value; }
    	}

        /// <summary>
        /// Advances to the next page.
        /// </summary>
        public void Forward()
        {
            MoveTo(this.CurrentPageIndex + 1);
        }

        /// <summary>
        /// Indicates whether it is possible to advance one page.
        /// </summary>
        /// <returns> True unless the current page is the last page.</returns>
        public bool ForwardEnabled
        {
            get { return _forwardEnabled; }
            protected set
            {
                if (_forwardEnabled != value)
                {
                    _forwardEnabled = value;
                    EventsHelper.Fire(_forwardEnabledChanged, this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Notifies that the <see cref="ForwardEnabled"/> property has changed.
        /// </summary>
        public event EventHandler ForwardEnabledChanged
        {
            add { _forwardEnabledChanged += value; }
            remove { _forwardEnabledChanged -= value; }
        }

        /// <summary>
        /// Sets the current page back to the previous page.
        /// </summary>
        public void Back()
        {
            MoveTo(this.CurrentPageIndex - 1);
        }

        /// <summary>
        /// Indicates whether it is possible to go back one page.
        /// </summary>
		/// <returns>True unless the current page is the first page.</returns>
        public bool BackEnabled
        {
            get { return _backEnabled; }
            protected set
            {
                if (_backEnabled != value)
                {
                    _backEnabled = value;
                    EventsHelper.Fire(_backEnabledChanged, this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Notifies that the <see cref="BackEnabled"/> property has changed.
        /// </summary>
        public event EventHandler BackEnabledChanged
        {
            add { _backEnabledChanged += value; }
            remove { _backEnabledChanged -= value; }
        }
        
        /// <summary>
        /// Causes the component to exit, accepting any changes made by the user.
        /// </summary>
        /// <remarks>
		/// Override this method if desired.
		/// </remarks>
        public virtual void Accept()
        {
			if (this.HasValidationErrors)
			{
				this.ShowValidation(true);
				return;
			}

			this.ExitCode = ApplicationComponentExitCode.Accepted;
            this.Host.Exit();
        }

        /// <summary>
        /// Indicates whether the accept button should be enabled.
        /// </summary>
        public bool AcceptEnabled
        {
            get { return _acceptEnabled; }
            protected set
            {
                if (_acceptEnabled != value)
                {
                    _acceptEnabled = value;
                    EventsHelper.Fire(_acceptEnabledChanged, this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Notifies that the <see cref="AcceptEnabled"/> property has changed.
        /// </summary>
        public event EventHandler AcceptEnabledChanged
        {
            add { _acceptEnabledChanged += value; }
            remove { _acceptEnabledChanged -= value; }
        }

		/// <summary>
		/// Gets whether an Apply button should be shown.
		/// </summary>
		public bool ShowApply
		{
			get { return _showApply; }
		}

		/// <summary>
		/// Gets whether or not the Apply button should be enabled.
		/// </summary>
		/// <remarks>
		/// When <see cref="ShowApply"/> is false, this property has no meaning.
		/// </remarks>
		public bool ApplyEnabled
		{
			get { return _applyEnabled; }
			protected set
			{
				if (_applyEnabled != value)
				{
					_applyEnabled = value;
					EventsHelper.Fire(_applyEnabledChanged, this, new EventArgs());
				}
			}
		}

		/// <summary>
		/// Fires when <see cref="ApplyEnabled"/> has changed.
		/// </summary>
		public event EventHandler ApplyEnabledChanged
		{
			add { _applyEnabledChanged += value; }
			remove { _applyEnabledChanged -= value; }
		}

		/// <summary>
		/// Applies any changes from the contained pages.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If this method is not overridden, it will essentially do nothing other
		/// than set <see cref="ApplyEnabled"/> to false; therefore, you should override
		/// it if <see cref="ShowApply"/> is true.
		/// </para>
		/// <para>
		/// If and only if there are no validation errors will <see cref="ApplyEnabled"/> be
		/// set to false.  Overriding methods can use the value of <see cref="ApplyEnabled"/> to
		/// decide whether or not to perform an action as a result of the user having clicked
		/// the Apply button (e.g. check that it is indeed false, then apply).
		/// </para>
		/// </remarks>
		public virtual void Apply()
		{
			Platform.CheckTrue(_showApply, "Show Apply");

			if (this.HasValidationErrors)
			{
				ShowValidation(this.HasValidationErrors);
				return;
			}

			ApplyEnabled = false;
		}
	
    	/// <summary>
        /// Causes the component to exit, discarding any changes made by the user.
        /// </summary>
        /// <remarks>
		/// Override this method if desired.
		/// </remarks>
        public virtual void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            this.Host.Exit();
        }

        #endregion


        /// <summary>
        /// Moves to the page at the specified index.
        /// </summary>
        protected override void MoveTo(int index)
        {
            base.MoveTo(index);

            this.ForwardEnabled = (this.CurrentPageIndex < this.Pages.Count - 1);
            this.BackEnabled = (this.CurrentPageIndex > 0);
        }

		/// <summary>
		/// Sets <see cref="AcceptEnabled"/> based on the value of <see cref="ApplicationComponent.Modified"/>.
		/// </summary>
        protected override void OnComponentModifiedChanged(IApplicationComponent component)
        {
            base.OnComponentModifiedChanged(component);
			this.ApplyEnabled = this.Modified;
			this.AcceptEnabled = true;
		}
    }
}
