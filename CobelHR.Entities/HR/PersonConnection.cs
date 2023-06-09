using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class PersonConnection : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "PersonConnection", "PersonConnection");

        #region Constructor
        public PersonConnection() : this(0)
        {

        }

        public PersonConnection(int id) : this(id, default)
        {

        }

        public PersonConnection(int id, byte[] timeStamp) : base(id, timeStamp, PersonConnection.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.ConnectionType ConnectionType { get; set; }
		
		public string Value { get; set; }
		
		public bool? IsEmergencyConnection { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					ConnectionType.Validate() &&
					Value.Validate() &&
					IsEmergencyConnection.Validate();
        }
    }
}
