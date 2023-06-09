using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS.Pharma
{
    public class Objective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "Objective", "Objective");

        #region Constructor
        public Objective() : this(0)
        {

        }

        public Objective(int id) : this(id, default)
        {

        }

        public Objective(int id, byte[] timeStamp) : base(id, timeStamp, Objective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }

        public PMS.Pharma.ObjectiveType ObjectiveType { get; set; }

        public string Title { get; set; }
		
        public decimal? Weight { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }
		
		public bool? IsFixed { get; set; }

        public int? CategoryId {  get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<KPI> ListOfKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
                    ObjectiveType.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate() &&
					IsFixed.Validate();
        }
    }
}
