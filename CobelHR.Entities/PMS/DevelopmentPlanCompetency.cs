using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class DevelopmentPlanCompetency : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "DevelopmentPlanCompetency", "DevelopmentPlanCompetency");

        #region Constructor
        public DevelopmentPlanCompetency() : this(0)
        {

        }

        public DevelopmentPlanCompetency(int id) : this(id, default)
        {

        }

        public DevelopmentPlanCompetency(int id, byte[] timeStamp) : base(id, timeStamp, DevelopmentPlanCompetency.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.IndividualDevelopmentPlan IndividualDevelopmentPlan { get; set; }
		
        public PMS.CompetencyItem CompetencyItem { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return IndividualDevelopmentPlan.Validate() &&
					CompetencyItem.Validate();
        }
    }
}
