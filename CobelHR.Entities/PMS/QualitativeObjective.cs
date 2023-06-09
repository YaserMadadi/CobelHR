using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class QualitativeObjective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "QualitativeObjective", "QualitativeObjective");

        #region Constructor
        public QualitativeObjective() : this(0)
        {

        }

        public QualitativeObjective(int id) : this(id, default)
        {

        }

        public QualitativeObjective(int id, byte[] timeStamp) : base(id, timeStamp, QualitativeObjective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
		public string Title { get; set; }
		
        public decimal? Weight { get; set; }
		
        public decimal? TotalKPIWeight { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }
		
		public bool? IsFixed { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<QualitativeKPI> ListOfQualitativeKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					TotalKPIWeight.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate() &&
					IsFixed.Validate();
        }
    }
}
