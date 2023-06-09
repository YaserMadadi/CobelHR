using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class FunctionalObjective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FunctionalObjective", "FunctionalObjective");

        #region Constructor
        public FunctionalObjective() : this(0)
        {

        }

        public FunctionalObjective(int id) : this(id, default)
        {

        }

        public FunctionalObjective(int id, byte[] timeStamp) : base(id, timeStamp, FunctionalObjective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public PMS.FunctionalObjective ParentalFunctionalObjective { get; set; }
		
		public string IndividualObjective { get; set; }
		
        public decimal? Weight { get; set; }
		
		public string Description { get; set; }
		
        public decimal? TotalKPIWeight { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<FunctionalKPI> ListOfFunctionalKPI { get; set; }

		[JsonIgnore]
		public List<FunctionalObjective> ListOfChildFunctionalObjective { get; set; }

		[JsonIgnore]
		public List<FunctionalObjectiveComment> ListOfFunctionalObjectiveComment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					ParentalFunctionalObjective.Validate() &&
					IndividualObjective.Validate() &&
					Weight.Validate() &&
					TotalKPIWeight.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate();
        }
    }
}
