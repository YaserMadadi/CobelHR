using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS.Pharma
{
    public class KPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "KPI", "KPI");

        #region Constructor
        public KPI() : this(0)
        {

        }

        public KPI(int id) : this(id, default)
        {

        }

        public KPI(int id, byte[] timeStamp) : base(id, timeStamp, KPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Pharma.Objective Objective { get; set; }
		
		public string Title { get; set; }
		
        public decimal? Weight { get; set; }
		
        public int? Target { get; set; }

        public decimal? Score { get; set; } = 0;
		
		public bool? IsFixed { get; set; } = false;

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Appraise> ListOfAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Objective.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					Target.Validate() &&
					Score.Validate() &&
					IsFixed.Validate();
        }
    }
}
