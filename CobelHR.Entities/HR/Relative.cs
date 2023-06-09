using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class Relative : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Relative", "Relative");

        #region Constructor
        public Relative() : this(0)
        {

        }

        public Relative(int id) : this(id, default)
        {

        }

        public Relative(int id, byte[] timeStamp) : base(id, timeStamp, Relative.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Peson { get; set; }
		
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public string NationalCode { get; set; }
		
		public DateTime? BirthDate { get; set; }
		
        public Base.HR.RelativeType RelationType { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Peson.Validate() &&
					FirstName.Validate() &&
					LastName.Validate() &&
					NationalCode.Validate() &&
					BirthDate.Validate() &&
					RelationType.Validate();
        }
    }
}
