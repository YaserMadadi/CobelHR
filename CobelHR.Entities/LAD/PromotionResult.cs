using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class PromotionResult : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "PromotionResult", "PromotionResult");

        #region Constructor
        public PromotionResult() : this(0)
        {

        }

        public PromotionResult(int id) : this(id, default)
        {

        }

        public PromotionResult(int id, byte[] timeStamp) : base(id, timeStamp, PromotionResult.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<PromotionAssessment> ListOfPromotionAssessment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
