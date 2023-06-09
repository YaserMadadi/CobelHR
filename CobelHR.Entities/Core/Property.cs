using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class Property : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Property", "Property");

        #region Constructor
        public Property() : this(0)
        {

        }

        public Property(int id) : this(id, default)
        {

        }

        public Property(int id, byte[] timeStamp) : base(id, timeStamp, Property.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.Entity Entity { get; set; }
		
		public string Title { get; set; }
		
		public string PersianSynonym { get; set; }
		
		public string Description { get; set; }
		
		public string FileName { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<PropertyOption> ListOfPropertyOption { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Entity.Validate() &&
					Title.Validate() &&
					PersianSynonym.Validate() &&
					FileName.Validate();
        }
    }
}
