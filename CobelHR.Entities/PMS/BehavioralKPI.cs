using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class BehavioralKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "BehavioralKPI", "BehavioralKPI");

        #region Constructor
        public BehavioralKPI() : this(0)
        {

        }

        public BehavioralKPI(int id) : this(id, default)
        {

        }

        public BehavioralKPI(int id, byte[] timeStamp) : base(id, timeStamp, BehavioralKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.BehavioralObjective BehavioralObjective { get; set; }
		
        public PMS.CompetencyItemKPI CompetencyItemKPI { get; set; }
		
        public decimal? Weight { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<BehavioralAppraise> ListOfBehavioralAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return BehavioralObjective.Validate() &&
					CompetencyItemKPI.Validate() &&
					Weight.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate();
        }
    }
}
