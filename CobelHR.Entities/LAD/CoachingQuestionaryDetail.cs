using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class CoachingQuestionaryDetail : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "CoachingQuestionaryDetail", "CoachingQuestionaryDetail");

        #region Constructor
        public CoachingQuestionaryDetail() : this(0)
        {

        }

        public CoachingQuestionaryDetail(int id) : this(id, default)
        {

        }

        public CoachingQuestionaryDetail(int id, byte[] timeStamp) : base(id, timeStamp, CoachingQuestionaryDetail.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.CoachingQuestionary CoachingQuestionary { get; set; }
		
		public DateTime? Date { get; set; }
		
        public string From { get; set; }
		
        public string To { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return CoachingQuestionary.Validate() &&
					Date.Validate() &&
					From.Validate() &&
					To.Validate();
        }
    }
}
