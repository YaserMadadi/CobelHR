using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class CoachConnectionLine : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "CoachConnectionLine", "CoachConnectionLine");

        #region Constructor
        public CoachConnectionLine() : this(0)
        {

        }

        public CoachConnectionLine(int id) : this(id, default)
        {

        }

        public CoachConnectionLine(int id, byte[] timeStamp) : base(id, timeStamp, CoachConnectionLine.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Coach Coach { get; set; }
		
        public Base.ConnectionType ConnectionType { get; set; }
		
		public string Number { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Coach.Validate() &&
					ConnectionType.Validate() &&
					Number.Validate();
        }
    }
}
