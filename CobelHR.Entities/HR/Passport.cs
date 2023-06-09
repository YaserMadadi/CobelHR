using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class Passport : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Passport", "Passport");

        #region Constructor
        public Passport() : this(0)
        {

        }

        public Passport(int id) : this(id, default)
        {

        }

        public Passport(int id, byte[] timeStamp) : base(id, timeStamp, Passport.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
		public string PassportNumber { get; set; }
		
		public DateTime? IssueDate { get; set; }
		
		public DateTime? ExpireDate { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					PassportNumber.Validate() &&
					IssueDate.Validate() &&
					ExpireDate.Validate();
        }
    }
}
