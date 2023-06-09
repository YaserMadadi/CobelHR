using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class BehavioralObjective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "BehavioralObjective", "BehavioralObjective");

        #region Constructor
        public BehavioralObjective() : this(0)
        {

        }

        public BehavioralObjective(int id) : this(id, default)
        {

        }

        public BehavioralObjective(int id, byte[] timeStamp) : base(id, timeStamp, BehavioralObjective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public PMS.CompetencyItem CompetencyItem { get; set; }
		
		public string Title { get; set; }
		
        public Base.PMS.ExpectedLevel ExpectedLevel { get; set; }
		
        public decimal? Weight { get; set; }
		
        public decimal? TotalKPIWeight { get; set; }
		
		public string Description { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<BehavioralKPI> ListOfBehavioralKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					CompetencyItem.Validate() &&
					Title.Validate() &&
					ExpectedLevel.Validate() &&
					Weight.Validate() &&
					TotalKPIWeight.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate();
        }
    }
}
