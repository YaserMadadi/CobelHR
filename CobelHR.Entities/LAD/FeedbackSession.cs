using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class FeedbackSession : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "FeedbackSession", "FeedbackSession");

        #region Constructor
        public FeedbackSession() : this(0)
        {

        }

        public FeedbackSession(int id) : this(id, default)
        {

        }

        public FeedbackSession(int id, byte[] timeStamp) : base(id, timeStamp, FeedbackSession.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
		public DateTime? Date { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					Date.Validate();
        }
    }
}
