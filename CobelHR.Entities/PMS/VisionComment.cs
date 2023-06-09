using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class VisionComment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "VisionComment", "VisionComment");

        #region Constructor
        public VisionComment() : this(0)
        {

        }

        public VisionComment(int id) : this(id, default)
        {

        }

        public VisionComment(int id, byte[] timeStamp) : base(id, timeStamp, VisionComment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Vision Vision { get; set; }
		
		public DateTime? Time { get; set; }
		
        public HR.Employee Commentator { get; set; }
		
		public string Title { get; set; }
		
		public string Content { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Vision.Validate() &&
					Time.Validate() &&
					Title.Validate() &&
					Content.Validate();
        }
    }
}
