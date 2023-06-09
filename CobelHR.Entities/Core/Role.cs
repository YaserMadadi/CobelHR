using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class Role : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Role", "Role");

        #region Constructor
        public Role() : this(0)
        {

        }

        public Role(int id) : this(id, default)
        {

        }

        public Role(int id, byte[] timeStamp) : base(id, timeStamp, Role.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<RoleMember> ListOfRoleMember { get; set; }

		[JsonIgnore]
		public List<RolePermission> ListOfRolePermission { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
