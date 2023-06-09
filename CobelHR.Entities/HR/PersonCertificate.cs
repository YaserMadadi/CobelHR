using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class PersonCertificate : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "PersonCertificate", "PersonCertificate");

        #region Constructor
        public PersonCertificate() : this(0)
        {

        }

        public PersonCertificate(int id) : this(id, default)
        {

        }

        public PersonCertificate(int id, byte[] timeStamp) : base(id, timeStamp, PersonCertificate.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.FieldCategory FieldCategory { get; set; }
		
		public string Title { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					FieldCategory.Validate() &&
					Title.Validate();
        }
    }
}
