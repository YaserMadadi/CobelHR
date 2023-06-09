using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class VisionApproved : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "VisionApproved", "VisionApproved");

        #region Constructor
        public VisionApproved() : this(0)
        {

        }

        public VisionApproved(int id) : this(id, default)
        {

        }

        public VisionApproved(int id, byte[] timeStamp) : base(id, timeStamp, VisionApproved.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Vision Vision { get; set; }
		
        public HR.Employee ByEmployee { get; set; }
		
        public Base.PMS.ApprovementType ApprovementType { get; set; }
		
		public DateTime? Date { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Vision.Validate() &&
					ByEmployee.Validate() &&
					ApprovementType.Validate() &&
					Date.Validate();
        }
    }
}
