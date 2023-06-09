using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class PersonDrivingLicense : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "PersonDrivingLicense", "PersonDrivingLicense");

        #region Constructor
        public PersonDrivingLicense() : this(0)
        {

        }

        public PersonDrivingLicense(int id) : this(id, default)
        {

        }

        public PersonDrivingLicense(int id, byte[] timeStamp) : base(id, timeStamp, PersonDrivingLicense.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.DrivingLicenseType DrivingLicenseType { get; set; }
		
		public DateTime? ExpireDate { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					DrivingLicenseType.Validate() &&
					ExpireDate.Validate();
        }
    }
}
