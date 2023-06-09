using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class EmployeeDetail : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "EmployeeDetail", "EmployeeDetail");

        #region Constructor
        public EmployeeDetail() : this(0)
        {

        }

        public EmployeeDetail(int id) : this(id, default)
        {

        }

        public EmployeeDetail(int id, byte[] timeStamp) : base(id, timeStamp, EmployeeDetail.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public Base.HoldingSection HoldingSection { get; set; }
		
        public int? EmployeeCode { get; set; }
		
        public Base.HR.EmploymentStatus EmploymentStatus { get; set; }
		
		public DateTime? StartWorkingDate { get; set; }
		
		public string TerminationDate { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					HoldingSection.Validate() &&
					EmployeeCode.Validate() &&
					EmploymentStatus.Validate() &&
					StartWorkingDate.Validate() &&
					TerminationDate.Validate() &&
					IsActive.Validate();
        }
    }
}
