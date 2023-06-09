using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class Impersonate : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Impersonate", "Impersonate");

        #region Constructor
        public Impersonate() : this(0)
        {

        }

        public Impersonate(int id) : this(id, default)
        {

        }

        public Impersonate(int id, byte[] timeStamp) : base(id, timeStamp, Impersonate.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string UserID { get; set; }
		
        public HR.Employee Employee { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return UserID.Validate() &&
					Employee.Validate() &&
					IsActive.Validate();
        }
    }
}
