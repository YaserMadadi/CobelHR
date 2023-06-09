using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class RolePermission : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "RolePermission", "RolePermission");

        #region Constructor
        public RolePermission() : this(0)
        {

        }

        public RolePermission(int id) : this(id, default)
        {

        }

        public RolePermission(int id, byte[] timeStamp) : base(id, timeStamp, RolePermission.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.Role Role { get; set; }
		
        public Core.Entity Entity { get; set; }
		
		public bool? AddPermission { get; set; }
		
		public bool? EditPermission { get; set; }
		
		public bool? DeletePermission { get; set; }
		
		public bool? ViewIndexPermission { get; set; }
		
		public bool? ViewLogPermission { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Role.Validate() &&
					Entity.Validate() &&
					AddPermission.Validate() &&
					EditPermission.Validate() &&
					DeletePermission.Validate() &&
					ViewIndexPermission.Validate() &&
					ViewLogPermission.Validate();
        }
    }
}
