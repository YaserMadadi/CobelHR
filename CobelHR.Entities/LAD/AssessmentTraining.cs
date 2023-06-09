using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class AssessmentTraining : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AssessmentTraining", "AssessmentTraining");

        #region Constructor
        public AssessmentTraining() : this(0)
        {

        }

        public AssessmentTraining(int id) : this(id, default)
        {

        }

        public AssessmentTraining(int id, byte[] timeStamp) : base(id, timeStamp, AssessmentTraining.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
		public string Course { get; set; }
		
        public Base.YearQuarter DeadLine { get; set; }
		
		public string Responsible { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					Course.Validate() &&
					DeadLine.Validate() &&
					Responsible.Validate();
        }
    }
}
