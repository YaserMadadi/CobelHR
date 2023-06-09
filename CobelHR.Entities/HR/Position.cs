using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.HR
{
    public class Position : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Position", "Position");

        #region Constructor
        public Position() : this(0)
        {

        }

        public Position(int id) : this(id, default)
        {

        }

        public Position(int id, byte[] timeStamp) : base(id, timeStamp, Position.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Position Parent { get; set; }
		
		public string PositionTitle { get; set; }
		
        public HR.Level Level { get; set; }
		
        public HR.Unit Unit { get; set; }
		
        public Base.HR.PositionDivision PositionDivision { get; set; }
		
        public Base.HR.PositionCategory PositionCategory { get; set; }
		
        public int? Capacity { get; set; }
		
        public int? ChildCount { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		

		[JsonIgnore]
		public List<Position> ListOfChildPosition { get; set; }

		[JsonIgnore]
		public List<PositionAssignment> ListOfPositionAssignment { get; set; }

		[JsonIgnore]
		public List<PromotionAssessment> ListOfProposedPosition_PromotionAssessment { get; set; }

		[JsonIgnore]
		public List<PromotionAssessment> ListOfCurrentPosition_PromotionAssessment { get; set; }

		[JsonIgnore]
		public List<RotationAssessment> ListOfProposedPosition_RotationAssessment { get; set; }

		[JsonIgnore]
		public List<RotationAssessment> ListOfCurrentPosition_RotationAssessment { get; set; }

		[JsonIgnore]
		public List<TargetSetting> ListOfTargetSetting { get; set; }

		[JsonIgnore]
		public List<Vision> ListOfVision { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Parent.Validate() &&
					PositionTitle.Validate() &&
					Level.Validate() &&
					Unit.Validate() &&
					PositionDivision.Validate() &&
					PositionCategory.Validate() &&
					Capacity.Validate() &&
					ChildCount.Validate() &&
					IsActive.Validate();
        }
    }
}
