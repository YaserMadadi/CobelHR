using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class PropertyOption : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "PropertyOption", "PropertyOption");

        #region Constructor
        public PropertyOption() : this(0)
        {

        }

        public PropertyOption(int id) : this(id, default)
        {

        }

        public PropertyOption(int id, byte[] timeStamp) : base(id, timeStamp, PropertyOption.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.Property Property { get; set; }
		
		public string Title { get; set; }
		
		public string Description { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Property.Validate() &&
					Title.Validate();
        }
    }
}
