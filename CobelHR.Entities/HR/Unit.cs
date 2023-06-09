using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class Unit : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Unit", "Unit");

        #region Constructor
        public Unit() : this(0)
        {

        }

        public Unit(int id) : this(id, default)
        {

        }

        public Unit(int id, byte[] timeStamp) : base(id, timeStamp, Unit.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public HR.Department Department { get; set; }
		
        public Base.HR.PositionDivision PositionDivision { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Position> ListOfPosition { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Department.Validate() &&
					PositionDivision.Validate() &&
					IsActive.Validate();
        }
    }
}
