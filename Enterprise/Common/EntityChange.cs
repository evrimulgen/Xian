#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Runtime.Serialization;

namespace ClearCanvas.Enterprise.Common
{
	/// <summary>
	/// Used by class <see cref="EntityChange"/> to record the type of change made to an entity.
	/// </summary>
	[Serializable]
	public enum EntityChangeType
	{
		Update = 0,
		Create = 1,
		Delete = 2
	}

	/// <summary>
	/// Represents a change made to an entity.
	/// </summary>
	[DataContract]
	public class EntityChange
	{
		private readonly EntityRef _entityRef;
		private readonly EntityChangeType _changeType;
		private readonly PropertyChange[] _propertyChanges;

		/// <summary>
		/// Constructor
		/// </summary>
		public EntityChange(EntityRef entityRef, EntityChangeType changeType, PropertyChange[] propertyChanges)
		{
			_entityRef = entityRef;
			_changeType = changeType;
			_propertyChanges = propertyChanges;
		}


		/// <summary>
		/// Gets the class name of the entity that changed.
		/// </summary>
		public string EntityClassName
		{
			get { return _entityRef.ClassName; }
		}

		/// <summary>
		/// Reference to the entity that changed
		/// </summary>
		public EntityRef EntityRef
		{
			get { return _entityRef; }
		}

		/// <summary>
		/// The type of change
		/// </summary>
		public EntityChangeType ChangeType
		{
			get { return _changeType; }
		}

		/// <summary>
		/// Gets an array of <see cref="PropertyChange"/> objects describing the changes
		/// made to the entity's property values.
		/// </summary>
		public PropertyChange[] PropertyChanges
		{
			get { return _propertyChanges; }
		}

		/// <summary>
		/// Gets the entity class that this change applies to, assuming the relevant
		/// assembly can be found.  If it can't be found, an exception will be thrown.
		/// </summary>
		/// <returns></returns>
		public Type GetEntityClass()
		{
			return Type.GetType(this.EntityClassName, true);
		}
	}
}
