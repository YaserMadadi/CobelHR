using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class FinalAppraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FinalAppraise", "FinalAppraise");

        #region Constructor
        public FinalAppraise() : this(0)
        {

        }

        public FinalAppraise(int id) : this(id, default)
        {

        }

        public FinalAppraise(int id, byte[] timeStamp) : base(id, timeStamp, FinalAppraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public decimal? ManagerFunctionalScore { get; set; }
		
        public decimal? ManagerBehavioralScore { get; set; }
		
        public decimal? FinalFunctionalScore { get; set; }
		
        public decimal? FinalBehavioralScore { get; set; }
		
		public string Comment { get; set; }
		
		public bool? IsApproved { get; set; }
		
        public PMS.ScoreCell ScoreCell { get; set; }
		
        public decimal? BonusCoefficient { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					ManagerFunctionalScore.Validate() &&
					ManagerBehavioralScore.Validate() &&
					FinalFunctionalScore.Validate() &&
					FinalBehavioralScore.Validate() &&
					IsApproved.Validate() &&
					ScoreCell.Validate() &&
					BonusCoefficient.Validate();
        }
    }
}
