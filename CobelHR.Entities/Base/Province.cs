using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Base;

namespace CobelHR.Entities.Base
{
    public class Province : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Province", "Province");

        #region Constructor
        public Province() : this(0)
        {

        }

        public Province(int id) : this(id, default)
        {

        }

        public Province(int id, byte[] timeStamp) : base(id, timeStamp, Province.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<City> ListOfCity { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
