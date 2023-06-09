using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class QuestionaryItem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "QuestionaryItem", "QuestionaryItem");

        #region Constructor
        public QuestionaryItem() : this(0)
        {

        }

        public QuestionaryItem(int id) : this(id, default)
        {

        }

        public QuestionaryItem(int id, byte[] timeStamp) : base(id, timeStamp, QuestionaryItem.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.QuestionaryType QuestionaryType { get; set; }
		
		public string QuestionTitle { get; set; }
		
        public int? Priority { get; set; }
		
        public LAD.AnswerType AnswerType { get; set; }
		
		public string HelpContext { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CoachingQuestionaryAnswered> ListOfCoachingQuestionaryAnswered { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return QuestionaryType.Validate() &&
					QuestionTitle.Validate() &&
					Priority.Validate() &&
					AnswerType.Validate() &&
					HelpContext.Validate();
        }
    }
}
