using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;
using CobelHR.Entities.Core;
using CobelHR.Entities.IDEA;

namespace CobelHR.Entities.HR
{
    public class Employee : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Employee", "Employee");

        #region Constructor
        public Employee() : this(0)
        {

        }

        public Employee(int id) : this(id, default)
        {

        }

        public Employee(int id, byte[] timeStamp) : base(id, timeStamp, Employee.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public int? LastEmployeeCode { get; set; }
		
        public Base.HoldingSection LastHoldingSection { get; set; }
		
		public string SAMAccountID { get; set; }
		
		public string EmailAddress { get; set; }
		
        public Base.HR.EmploymentStatus EmploymentStatus { get; set; }
		
		public string LastCity { get; set; }
		
		public string LastDepartment { get; set; }
		
		public string LastPosition { get; set; }
		
		public DateTime? StartWorkingInHoldingDate { get; set; }
		
		public string LastTerminationDate { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Assessment> ListOfAssessment { get; set; }

		[JsonIgnore]
		public List<BehavioralAppraise> ListOfAppraiser_BehavioralAppraise { get; set; }

		[JsonIgnore]
		public List<Coaching> ListOfCoaching { get; set; }

		[JsonIgnore]
		public List<Contract> ListOfContract { get; set; }

		[JsonIgnore]
		public List<CriticalIncident> ListOfCriticalIncident { get; set; }

		[JsonIgnore]
		public List<CriticalIncidentRecognition> ListOfWriter_CriticalIncidentRecognition { get; set; }

		[JsonIgnore]
		public List<EmployeeDetail> ListOfEmployeeDetail { get; set; }

		[JsonIgnore]
		public List<EmployeeEvent> ListOfEmployeeEvent { get; set; }

		[JsonIgnore]
		public List<EmployeeNotification> ListOfEmployeeNotification { get; set; }

		[JsonIgnore]
		public List<FunctionalAppraise> ListOfAppraiser_FunctionalAppraise { get; set; }

		[JsonIgnore]
		public List<FunctionalKPIComment> ListOfCommenter_FunctionalKPIComment { get; set; }

		[JsonIgnore]
		public List<FunctionalObjectiveComment> ListOfCommenter_FunctionalObjectiveComment { get; set; }

		[JsonIgnore]
		public List<Impersonate> ListOfImpersonate { get; set; }

		[JsonIgnore]
		public List<PositionAssignment> ListOfPositionAssignment { get; set; }

		[JsonIgnore]
		public List<QualitativeAppraise> ListOfAppraiser_QualitativeAppraise { get; set; }

		[JsonIgnore]
		public List<RoleMember> ListOfRoleMember { get; set; }

		[JsonIgnore]
		public List<TargetSetting> ListOfTargetSetting { get; set; }

		[JsonIgnore]
		public List<Training> ListOfTraining { get; set; }

		[JsonIgnore]
		public List<Vision> ListOfVision { get; set; }

		[JsonIgnore]
		public List<VisionApproved> ListOfByEmployee_VisionApproved { get; set; }

		[JsonIgnore]
		public List<VisionComment> ListOfCommentator_VisionComment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					LastEmployeeCode.Validate() &&
					LastHoldingSection.Validate() &&
					SAMAccountID.Validate() &&
					EmailAddress.Validate() &&
					EmploymentStatus.Validate() &&
					LastCity.Validate() &&
					LastDepartment.Validate() &&
					LastPosition.Validate() &&
					StartWorkingInHoldingDate.Validate() &&
					LastTerminationDate.Validate() &&
					IsActive.Validate();
        }
    }
}
