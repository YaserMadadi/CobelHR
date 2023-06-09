using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class WorkExperience : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "WorkExperience", "WorkExperience");

        #region Constructor
        public WorkExperience() : this(0)
        {

        }

        public WorkExperience(int id) : this(id, default)
        {

        }

        public WorkExperience(int id, byte[] timeStamp) : base(id, timeStamp, WorkExperience.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
		public string PersianCompanyName { get; set; }
		
		public string EnglishCompanyName { get; set; }
		
		public string PersianPositionName { get; set; }
		
		public string EnglishPositionName { get; set; }
		
		public DateTime? FromDate { get; set; }
		
		public DateTime? ToDate { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					PersianCompanyName.Validate() &&
					EnglishCompanyName.Validate() &&
					PersianPositionName.Validate() &&
					EnglishPositionName.Validate() &&
					FromDate.Validate() &&
					ToDate.Validate();
        }
    }
}
