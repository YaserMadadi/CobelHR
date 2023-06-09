using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class UserAccount : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "UserAccount", "UserAccount");

        #region Constructor
        public UserAccount() : this(0)
        {

        }

        public UserAccount(int id) : this(id, default)
        {

        }

        public UserAccount(int id, byte[] timeStamp) : base(id, timeStamp, UserAccount.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
		public string UserName { get; set; }
		
		public string Password { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					UserName.Validate() &&
					Password.Validate() &&
					IsActive.Validate();
        }
    }
}
