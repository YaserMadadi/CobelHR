using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class HoldingSection : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "HoldingSection", "HoldingSection");

        #region Constructor
        public HoldingSection() : this(0)
        {

        }

        public HoldingSection(int id) : this(id, default)
        {

        }

        public HoldingSection(int id, byte[] timeStamp) : base(id, timeStamp, HoldingSection.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public string DomainName { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Employee> ListOfLastHoldingSection_Employee { get; set; }

		[JsonIgnore]
		public List<EmployeeDetail> ListOfEmployeeDetail { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					DomainName.Validate() &&
					IsActive.Validate();
        }
    }
}
