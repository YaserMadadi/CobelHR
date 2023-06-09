using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class ApproverType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "ApproverType", "ApproverType");

        #region Constructor
        public ApproverType() : this(0)
        {

        }

        public ApproverType(int id) : this(id, default)
        {

        }

        public ApproverType(int id, byte[] timeStamp) : base(id, timeStamp, ApproverType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AppraisalApproverConfig> ListOfAppraisalApproverConfig { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
