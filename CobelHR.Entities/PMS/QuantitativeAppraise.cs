using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class QuantitativeAppraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "QuantitativeAppraise", "QuantitativeAppraise");

        #region Constructor
        public QuantitativeAppraise() : this(0)
        {

        }

        public QuantitativeAppraise(int id) : this(id, default)
        {

        }

        public QuantitativeAppraise(int id, byte[] timeStamp) : base(id, timeStamp, QuantitativeAppraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public decimal? Score { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					Score.Validate();
        }
    }
}
