/*------------------------------------------------------------------------
<generated>
     This code was generated by The NuSoft Framework v3.0
     Generated at 10/08/2012 7:48:48 PM.

     The NuSoft Framework is an open source project developed
     by NuSoft Solutions (http://www.nusoftsolutions.com).
     The latest version of the framework templates and detailed license
     is available at http://www.codeplex.com/NuSoftFramework.

     This file will be overwritten when regenerating your code.
</generated>
------------------------------------------------------------------------*/

using System;

namespace HealthStop.Business.Framework
{
	/// <summary>
	/// A custom EntityEventArgs class that has a reference to the Entity firing the event
	/// </summary>
    public class EntityValidationEventArgs : EntityEventArgs
    {		
		private string _validationGroup;
		/// <summary>
		/// The validation group that is being validated.
		/// </summary>
		public string ValidationGroup
		{
			get { return _validationGroup; }
		}
		
		private string _propertyName;
		/// <summary>
		/// The property that is being validated.
		/// </summary>
		public string PropertyName
		{
			get { return _propertyName; }
		}
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityValidationEventArgs(EntityBase entity, string propertyName, string validationGroup) : base(entity)
        {
			this._propertyName = propertyName;
			this._validationGroup = validationGroup;
        }
		
		/// <summary>
		/// Public constructor taking the entity and a helper
		/// </summary>
        public EntityValidationEventArgs(EntityBase entity, SqlHelper helper, string propertyName, string validationGroup) : base(entity, helper)
        {
			this._propertyName = propertyName;
			this._validationGroup = validationGroup;
        }

		/// <summary>
		/// Public constructor taking the entity
		/// </summary>
        public EntityValidationEventArgs(EntityBase entity) : base(entity) { }

		/// <summary>
		/// Public constructor taking the entity and the helper
		/// </summary>
        public EntityValidationEventArgs(EntityBase entity, SqlHelper helper) : base(entity, helper) { }
    }
}
