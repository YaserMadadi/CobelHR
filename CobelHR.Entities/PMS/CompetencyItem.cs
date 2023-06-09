using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class CompetencyItem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CompetencyItem", "CompetencyItem");

        #region Constructor
        public CompetencyItem() : this(0)
        {

        }

        public CompetencyItem(int id) : this(id, default)
        {

        }

        public CompetencyItem(int id, byte[] timeStamp) : base(id, timeStamp, CompetencyItem.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AssessmentScore> ListOfAssessmentScore { get; set; }

		[JsonIgnore]
		public List<BehavioralObjective> ListOfBehavioralObjective { get; set; }

		[JsonIgnore]
		public List<CompetencyItemKPI> ListOfCompetencyItemKPI { get; set; }

		[JsonIgnore]
		public List<DevelopmentPlanCompetency> ListOfDevelopmentPlanCompetency { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
