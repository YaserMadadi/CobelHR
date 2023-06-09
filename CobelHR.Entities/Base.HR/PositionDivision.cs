using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class PositionDivision : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "PositionDivision", "PositionDivision");

        #region Constructor
        public PositionDivision() : this(0)
        {

        }

        public PositionDivision(int id) : this(id, default)
        {

        }

        public PositionDivision(int id, byte[] timeStamp) : base(id, timeStamp, PositionDivision.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Position> ListOfPosition { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
