using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class AnswerType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AnswerType", "AnswerType");

        #region Constructor
        public AnswerType() : this(0)
        {

        }

        public AnswerType(int id) : this(id, default)
        {

        }

        public AnswerType(int id, byte[] timeStamp) : base(id, timeStamp, AnswerType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public string Comment { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AnswerTypeItem> ListOfAnswerTypeItem { get; set; }

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
