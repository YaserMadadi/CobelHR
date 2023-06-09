using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class ConnectionType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "ConnectionType", "ConnectionType");

        #region Constructor
        public ConnectionType() : this(0)
        {

        }

        public ConnectionType(int id) : this(id, default)
        {

        }

        public ConnectionType(int id, byte[] timeStamp) : base(id, timeStamp, ConnectionType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AssessorConnectionLine> ListOfAssessorConnectionLine { get; set; }

		[JsonIgnore]
		public List<CoachConnectionLine> ListOfCoachConnectionLine { get; set; }

		[JsonIgnore]
		public List<PersonConnection> ListOfPersonConnection { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
