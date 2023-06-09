using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class QualitativeKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "QualitativeKPI", "QualitativeKPI");

        #region Constructor
        public QualitativeKPI() : this(0)
        {

        }

        public QualitativeKPI(int id) : this(id, default)
        {

        }

        public QualitativeKPI(int id, byte[] timeStamp) : base(id, timeStamp, QualitativeKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.QualitativeObjective QualitativeObjective { get; set; }
		
		public string Title { get; set; }
		
        public decimal? Weight { get; set; }
		
        public int? Target { get; set; }
		
        public decimal? EmployeeScore { get; set; }
		
        public decimal? ManagerScore { get; set; }
		
		public string Description { get; set; }
		
		public bool? IsFixed { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<QualitativeAppraise> ListOfQualitativeAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return QualitativeObjective.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					Target.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate() &&
					IsFixed.Validate();
        }
    }
}
