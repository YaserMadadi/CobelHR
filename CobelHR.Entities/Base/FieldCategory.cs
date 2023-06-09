using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class FieldCategory : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "FieldCategory", "FieldCategory");

        #region Constructor
        public FieldCategory() : this(0)
        {

        }

        public FieldCategory(int id) : this(id, default)
        {

        }

        public FieldCategory(int id, byte[] timeStamp) : base(id, timeStamp, FieldCategory.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<PersonCertificate> ListOfPersonCertificate { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
