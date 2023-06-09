using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class RoleMember : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "RoleMember", "RoleMember");

        #region Constructor
        public RoleMember() : this(0)
        {

        }

        public RoleMember(int id) : this(id, default)
        {

        }

        public RoleMember(int id, byte[] timeStamp) : base(id, timeStamp, RoleMember.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public Core.Role Role { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Role.Validate();
        }
    }
}
