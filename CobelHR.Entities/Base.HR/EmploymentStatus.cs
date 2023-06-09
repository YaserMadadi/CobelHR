using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class EmploymentStatus : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "EmploymentStatus", "EmploymentStatus");

        #region Constructor
        public EmploymentStatus() : this(0)
        {

        }

        public EmploymentStatus(int id) : this(id, default)
        {

        }

        public EmploymentStatus(int id, byte[] timeStamp) : base(id, timeStamp, EmploymentStatus.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string EnglishTitle { get; set; }
		
		public string PersianTitle { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Employee> ListOfEmployee { get; set; }

		[JsonIgnore]
		public List<EmployeeDetail> ListOfEmployeeDetail { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return EnglishTitle.Validate() &&
					PersianTitle.Validate() &&
					IsActive.Validate();
        }
    }
}
