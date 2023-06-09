using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class AssessmentScore : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AssessmentScore", "AssessmentScore");

        #region Constructor
        public AssessmentScore() : this(0)
        {

        }

        public AssessmentScore(int id) : this(id, default)
        {

        }

        public AssessmentScore(int id, byte[] timeStamp) : base(id, timeStamp, AssessmentScore.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
        public PMS.CompetencyItem CompetencyItem { get; set; }
		
        public int? ExpectedScore { get; set; }
		
        public int? EmployeeScore { get; set; }
		
        public int? ManagerScore { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					CompetencyItem.Validate() &&
					ExpectedScore.Validate() &&
					EmployeeScore.Validate() &&
					ManagerScore.Validate();
        }
    }
}
