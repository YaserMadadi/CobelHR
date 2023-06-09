using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class QuestionaryType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "QuestionaryType", "QuestionaryType");

        #region Constructor
        public QuestionaryType() : this(0)
        {

        }

        public QuestionaryType(int id) : this(id, default)
        {

        }

        public QuestionaryType(int id, byte[] timeStamp) : base(id, timeStamp, QuestionaryType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CoachingQuestionary> ListOfCoachingQuestionary { get; set; }

		[JsonIgnore]
		public List<QuestionaryItem> ListOfQuestionaryItem { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
