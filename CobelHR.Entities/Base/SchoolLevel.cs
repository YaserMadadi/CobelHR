using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class SchoolLevel : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "SchoolLevel", "SchoolLevel");

        #region Constructor
        public SchoolLevel() : this(0)
        {

        }

        public SchoolLevel(int id) : this(id, default)
        {

        }

        public SchoolLevel(int id, byte[] timeStamp) : base(id, timeStamp, SchoolLevel.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<SchoolHistory> ListOfSchoolHistory { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
