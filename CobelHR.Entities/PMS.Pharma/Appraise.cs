using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS.Pharma
{
    public class Appraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "Appraise", "Appraise");

        #region Constructor
        public Appraise() : this(0)
        {

        }

        public Appraise(int id) : this(id, default)
        {

        }

        public Appraise(int id, byte[] timeStamp) : base(id, timeStamp, Appraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Pharma.KPI KPI { get; set; }
		
		public DateTime? Date { get; set; }
		
        public HR.Employee Appraiser { get; set; }
		
        public int? Actual { get; set; }
		
        public decimal? Score { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return KPI.Validate() &&
					Date.Validate() &&
					Appraiser.Validate() &&
					Actual.Validate() &&
					Score.Validate();
        }
    }
}
