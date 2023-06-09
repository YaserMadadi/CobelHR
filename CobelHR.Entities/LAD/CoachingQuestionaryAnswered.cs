using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class CoachingQuestionaryAnswered : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "CoachingQuestionaryAnswered", "CoachingQuestionaryAnswered");

        #region Constructor
        public CoachingQuestionaryAnswered() : this(0)
        {

        }

        public CoachingQuestionaryAnswered(int id) : this(id, default)
        {

        }

        public CoachingQuestionaryAnswered(int id, byte[] timeStamp) : base(id, timeStamp, CoachingQuestionaryAnswered.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.CoachingQuestionary CoachingQuestionary { get; set; }
		
        public LAD.QuestionaryItem QuestionaryItem { get; set; }
		
        public int? AnswerValue { get; set; }
		
		public string AnswerText { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return CoachingQuestionary.Validate() &&
					QuestionaryItem.Validate() &&
					AnswerValue.Validate() &&
					AnswerText.Validate();
        }
    }
}
