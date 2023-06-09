using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class CoachingSession : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "CoachingSession", "CoachingSession");

        #region Constructor
        public CoachingSession() : this(0)
        {

        }

        public CoachingSession(int id) : this(id, default)
        {

        }

        public CoachingSession(int id, byte[] timeStamp) : base(id, timeStamp, CoachingSession.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Coaching Coaching { get; set; }
		
		public DateTime? Date { get; set; }
		
		public string Note { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Coaching.Validate() &&
					Date.Validate() &&
					Note.Validate();
        }
    }
}
