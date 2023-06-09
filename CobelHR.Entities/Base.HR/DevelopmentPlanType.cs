using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Base.HR
{
    public class DevelopmentPlanType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "DevelopmentPlanType", "DevelopmentPlanType");

        #region Constructor
        public DevelopmentPlanType() : this(0)
        {

        }

        public DevelopmentPlanType(int id) : this(id, default)
        {

        }

        public DevelopmentPlanType(int id, byte[] timeStamp) : base(id, timeStamp, DevelopmentPlanType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
