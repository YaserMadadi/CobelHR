using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class FunctionalAppraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FunctionalAppraise", "FunctionalAppraise");

        #region Constructor
        public FunctionalAppraise() : this(0)
        {

        }

        public FunctionalAppraise(int id) : this(id, default)
        {

        }

        public FunctionalAppraise(int id, byte[] timeStamp) : base(id, timeStamp, FunctionalAppraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.FunctionalKPI FunctionalKPI { get; set; }
		
		public DateTime? Date { get; set; }
		
        public HR.Employee Appraiser { get; set; }
		
        public Base.PMS.AppraiseType AppraiseType { get; set; }
		
        public int? ActualValue { get; set; }
		
        public decimal? Score { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return FunctionalKPI.Validate() &&
					Date.Validate() &&
					Appraiser.Validate() &&
					AppraiseType.Validate() &&
					ActualValue.Validate() &&
					Score.Validate();
        }
    }
}
