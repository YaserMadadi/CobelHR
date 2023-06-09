using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class PositionAssignmentRepeal : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "PositionAssignmentRepeal", "PositionAssignmentRepeal");

        #region Constructor
        public PositionAssignmentRepeal() : this(0)
        {

        }

        public PositionAssignmentRepeal(int id) : this(id, default)
        {

        }

        public PositionAssignmentRepeal(int id, byte[] timeStamp) : base(id, timeStamp, PositionAssignmentRepeal.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.PositionAssignment PositionAssignment { get; set; }
		
		public DateTime? Date { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return PositionAssignment.Validate() &&
					Date.Validate();
        }
    }
}
