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
using ClearCanvas.Enterprise.Common;
namespace ClearCanvas.Enterprise.Core
{
	/// <summary>
	/// Base interface for a persistence context. See <see cref="IReadContext"/> and <see cref="IUpdateContext"/>.
	/// </summary>
	/// <remarks>
	/// A persistence context is an implementation of the unit-of-work
	/// and identity map patterns, and defines a scope in which the application can perform a set of operations on
	/// a persistent store.  This interface is not implemented directly.
	/// </remarks>
	/// <seealso cref="IReadContext"/>
	/// <seealso cref="IUpdateContext"/>
	public interface IPersistenceContext : IPersistenceBrokerFactory, IDisposable
	{
		/// <summary>
		/// Locks the specified entity into the context. 
		/// </summary>
		/// <remarks>
		/// If this is an update context, the entity will be treated as "clean".
		/// Use the other overload to specify that the entity is new or dirty.</remarks>
		/// <param name="entity"></param>
		void Lock(Entity entity);

		/// <summary>
		/// Locks the specified entity into the context with the specified <see cref="DirtyState"/>.
		/// </summary>
		/// <remarks>
		/// Note that it does not make sense to lock an entity into a read context with <see cref="DirtyState.Dirty"/>,
		/// and an exception will be thrown.
		/// </remarks>
		/// <param name="entity"></param>
		/// <param name="state"></param>
		void Lock(Entity entity, DirtyState state);

		/// <summary>
		/// Loads the specified entity into this context.
		/// </summary>
		/// <param name="entityRef"></param>
		/// <returns></returns>
		TEntity Load<TEntity>(EntityRef entityRef) where TEntity : Entity;

		/// <summary>
		/// Loads the specified entity into this context.
		/// </summary>
		/// <param name="entityRef"></param>
		/// <param name="flags"></param>
		/// <returns></returns>
		TEntity Load<TEntity>(EntityRef entityRef, EntityLoadFlags flags) where TEntity : Entity;

		/// <summary>
		/// Loads the specified entity into this context.
		/// </summary>
		Entity Load(EntityRef entityRef, EntityLoadFlags flags);

		/// <summary>
		/// Synchronizes the state of the persistent store (database) with the state of this context.
		/// </summary>
		/// <remarks>
		/// This method will ensure that any pending writes to the persistent store are flushed, and that
		/// any generated object identifiers for new persistent objects are generated and assigned to those objects. 
		/// </remarks>
		void SynchState();
	}
}
