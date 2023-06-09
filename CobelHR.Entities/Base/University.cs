using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class University : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "University", "University");

        #region Constructor
        public University() : this(0)
        {

        }

        public University(int id) : this(id, default)
        {

        }

        public University(int id, byte[] timeStamp) : base(id, timeStamp, University.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public Base.City City { get; set; }
		
		public bool? IsExternal { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<UniversityHistory> ListOfUniversityHistory { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					City.Validate() &&
					IsExternal.Validate();
        }
    }
}
