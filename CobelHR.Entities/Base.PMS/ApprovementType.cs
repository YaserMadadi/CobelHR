using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class ApprovementType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "ApprovementType", "ApprovementType");

        #region Constructor
        public ApprovementType() : this(0)
        {

        }

        public ApprovementType(int id) : this(id, default)
        {

        }

        public ApprovementType(int id, byte[] timeStamp) : base(id, timeStamp, ApprovementType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<VisionApproved> ListOfVisionApproved { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
