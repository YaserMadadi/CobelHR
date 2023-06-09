using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class RotationAssessment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "RotationAssessment", "RotationAssessment");

        #region Constructor
        public RotationAssessment() : this(0)
        {

        }

        public RotationAssessment(int id) : this(id, default)
        {

        }

        public RotationAssessment(int id, byte[] timeStamp) : base(id, timeStamp, RotationAssessment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
		public string PromotedDate { get; set; }
		
        public HR.Position CurrentPosition { get; set; }
		
        public HR.Position ProposedPosition { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					PromotedDate.Validate() &&
					CurrentPosition.Validate() &&
					ProposedPosition.Validate();
        }
    }
}
