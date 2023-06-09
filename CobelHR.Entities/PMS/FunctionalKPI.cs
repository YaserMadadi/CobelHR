using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class FunctionalKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FunctionalKPI", "FunctionalKPI");

        #region Constructor
        public FunctionalKPI() : this(0)
        {

        }

        public FunctionalKPI(int id) : this(id, default)
        {

        }

        public FunctionalKPI(int id, byte[] timeStamp) : base(id, timeStamp, FunctionalKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.FunctionalObjective FunctionalObjective { get; set; }
		
		public string Title { get; set; }
		
        public decimal? Weight { get; set; }
		
        public Base.PMS.MeasurementUnit MeasurementUnit { get; set; }
		
        public float? MidTarget { get; set; }
		
        public float? AnnualTarget { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }
		
		public string Description { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<FunctionalAppraise> ListOfFunctionalAppraise { get; set; }

		[JsonIgnore]
		public List<FunctionalKPIComment> ListOfFunctionalKPIComment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return FunctionalObjective.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					MeasurementUnit.Validate() &&
					MidTarget.Validate() &&
					AnnualTarget.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate();
        }
    }
}
