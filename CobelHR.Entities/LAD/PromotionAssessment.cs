using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class PromotionAssessment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "PromotionAssessment", "PromotionAssessment");

        #region Constructor
        public PromotionAssessment() : this(0)
        {

        }

        public PromotionAssessment(int id) : this(id, default)
        {

        }

        public PromotionAssessment(int id, byte[] timeStamp) : base(id, timeStamp, PromotionAssessment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
		public string PromotedDate { get; set; }
		
        public HR.Position CurrentPosition { get; set; }
		
        public HR.Position ProposedPosition { get; set; }
		
        public LAD.PromotionResult PromotionResult { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					PromotedDate.Validate() &&
					CurrentPosition.Validate() &&
					ProposedPosition.Validate() &&
					PromotionResult.Validate();
        }
    }
}
