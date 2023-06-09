using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class AnswerTypeItem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AnswerTypeItem", "AnswerTypeItem");

        #region Constructor
        public AnswerTypeItem() : this(0)
        {

        }

        public AnswerTypeItem(int id) : this(id, default)
        {

        }

        public AnswerTypeItem(int id, byte[] timeStamp) : base(id, timeStamp, AnswerTypeItem.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.AnswerType AnswerType { get; set; }
		
		public string Title { get; set; }
		
        public int? Value { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return AnswerType.Validate() &&
					Title.Validate() &&
					Value.Validate() &&
					IsActive.Validate();
        }
    }
}
