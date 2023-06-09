using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class CoachingQuestionary : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "CoachingQuestionary", "CoachingQuestionary");

        #region Constructor
        public CoachingQuestionary() : this(0)
        {

        }

        public CoachingQuestionary(int id) : this(id, default)
        {

        }

        public CoachingQuestionary(int id, byte[] timeStamp) : base(id, timeStamp, CoachingQuestionary.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.QuestionaryType QuestionaryType { get; set; }
		
        public LAD.Assessment Assessment { get; set; }
		
        public HR.Person ResponsiblePerson { get; set; }
		
		public bool? IsActive { get; set; }
		
		public bool? IsDone { get; set; }
		
		public string Average { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CoachingQuestionaryAnswered> ListOfCoachingQuestionaryAnswered { get; set; }

		[JsonIgnore]
		public List<CoachingQuestionaryDetail> ListOfCoachingQuestionaryDetail { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return QuestionaryType.Validate() &&
					Assessment.Validate() &&
					ResponsiblePerson.Validate() &&
					IsActive.Validate() &&
					IsDone.Validate() &&
					Average.Validate();
        }
    }
}
