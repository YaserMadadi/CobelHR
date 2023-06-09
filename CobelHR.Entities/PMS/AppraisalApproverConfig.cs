using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class AppraisalApproverConfig : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "AppraisalApproverConfig", "AppraisalApproverConfig");

        #region Constructor
        public AppraisalApproverConfig() : this(0)
        {

        }

        public AppraisalApproverConfig(int id) : this(id, default)
        {

        }

        public AppraisalApproverConfig(int id, byte[] timeStamp) : base(id, timeStamp, AppraisalApproverConfig.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.HR.PositionCategory DepartmentCategory { get; set; }
		
        public Base.PMS.ApproverType ApproverType { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return DepartmentCategory.Validate() &&
					ApproverType.Validate();
        }
    }
}
