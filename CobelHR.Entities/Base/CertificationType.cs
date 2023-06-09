using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class CertificationType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "CertificationType", "CertificationType");

        #region Constructor
        public CertificationType() : this(0)
        {

        }

        public CertificationType(int id) : this(id, default)
        {

        }

        public CertificationType(int id, byte[] timeStamp) : base(id, timeStamp, CertificationType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<UniversityHistory> ListOfUniversityHistory { get; set; }

		#endregion

        
        public override bool Validate()
        {//test
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
