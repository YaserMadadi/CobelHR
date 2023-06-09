using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class AssessorConnectionLine : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AssessorConnectionLine", "AssessorConnectionLine");

        #region Constructor
        public AssessorConnectionLine() : this(0)
        {

        }

        public AssessorConnectionLine(int id) : this(id, default)
        {

        }

        public AssessorConnectionLine(int id, byte[] timeStamp) : base(id, timeStamp, AssessorConnectionLine.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessor Assessor { get; set; }
		
        public Base.ConnectionType ConnectionType { get; set; }
		
		public string Number { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessor.Validate() &&
					ConnectionType.Validate() &&
					Number.Validate();
        }
    }
}
