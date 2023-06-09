using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class PositionAssignment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "PositionAssignment", "PositionAssignment");

        #region Constructor
        public PositionAssignment() : this(0)
        {

        }

        public PositionAssignment(int id) : this(id, default)
        {

        }

        public PositionAssignment(int id, byte[] timeStamp) : base(id, timeStamp, PositionAssignment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public HR.Position Position { get; set; }
		
		public DateTime? FromDate { get; set; }
		
		public string Comment { get; set; }
		
		public bool? IsAlive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<PositionAssignmentRepeal> ListOfPositionAssignmentRepeal { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Position.Validate() &&
					FromDate.Validate() &&
					IsAlive.Validate();
        }
    }
}
