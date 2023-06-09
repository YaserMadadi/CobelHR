using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class DrivingLicenseType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "DrivingLicenseType", "DrivingLicenseType");

        #region Constructor
        public DrivingLicenseType() : this(0)
        {

        }

        public DrivingLicenseType(int id) : this(id, default)
        {

        }

        public DrivingLicenseType(int id, byte[] timeStamp) : base(id, timeStamp, DrivingLicenseType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<PersonDrivingLicense> ListOfPersonDrivingLicense { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
