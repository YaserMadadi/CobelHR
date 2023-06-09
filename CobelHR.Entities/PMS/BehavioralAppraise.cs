using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class BehavioralAppraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "BehavioralAppraise", "BehavioralAppraise");

        #region Constructor
        public BehavioralAppraise() : this(0)
        {

        }

        public BehavioralAppraise(int id) : this(id, default)
        {

        }

        public BehavioralAppraise(int id, byte[] timeStamp) : base(id, timeStamp, BehavioralAppraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.BehavioralKPI BehavioralKPI { get; set; }
		
        public Base.PMS.AppraiseType AppraiseType { get; set; }
		
		public DateTime? Date { get; set; }
		
        public HR.Employee Appraiser { get; set; }
		
        public decimal? Score { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return BehavioralKPI.Validate() &&
					AppraiseType.Validate() &&
					Date.Validate() &&
					Appraiser.Validate() &&
					Score.Validate();
        }
    }
}
