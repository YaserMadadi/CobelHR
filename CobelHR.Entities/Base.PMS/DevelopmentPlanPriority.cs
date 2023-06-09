using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class DevelopmentPlanPriority : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "DevelopmentPlanPriority", "DevelopmentPlanPriority");

        #region Constructor
        public DevelopmentPlanPriority() : this(0)
        {

        }

        public DevelopmentPlanPriority(int id) : this(id, default)
        {

        }

        public DevelopmentPlanPriority(int id, byte[] timeStamp) : base(id, timeStamp, DevelopmentPlanPriority.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<IndividualDevelopmentPlan> ListOfPriority_IndividualDevelopmentPlan { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
