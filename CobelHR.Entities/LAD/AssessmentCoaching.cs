using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class AssessmentCoaching : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AssessmentCoaching", "AssessmentCoaching");

        #region Constructor
        public AssessmentCoaching() : this(0)
        {

        }

        public AssessmentCoaching(int id) : this(id, default)
        {

        }

        public AssessmentCoaching(int id, byte[] timeStamp) : base(id, timeStamp, AssessmentCoaching.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
        public LAD.Coaching Coaching { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					Coaching.Validate();
        }
    }
}
