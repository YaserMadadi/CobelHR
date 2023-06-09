using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class AppraiseResult : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "AppraiseResult", "AppraiseResult");

        #region Constructor
        public AppraiseResult() : this(0)
        {

        }

        public AppraiseResult(int id) : this(id, default)
        {

        }

        public AppraiseResult(int id, byte[] timeStamp) : base(id, timeStamp, AppraiseResult.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.TargetSetting TargetSetting { get; set; }
		
        public Base.PMS.AppraiseType AppraiseType { get; set; }
		
        public decimal? FunctionalScore { get; set; }
		
        public decimal? BehavioralScore { get; set; }
		
        public decimal? QuantitativeScore { get; set; }
		
        public decimal? QualitativeScore { get; set; }
		
        public decimal? TotalScore { get; set; }
		
        public PMS.ScoreCell ScoreCell { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return TargetSetting.Validate() &&
					AppraiseType.Validate() &&
					FunctionalScore.Validate() &&
					BehavioralScore.Validate() &&
					QuantitativeScore.Validate() &&
					QualitativeScore.Validate() &&
					TotalScore.Validate() &&
					ScoreCell.Validate();
        }
    }
}
