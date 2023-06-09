using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class Entity : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Entity", "Entity");

        #region Constructor
        public Entity() : this(0)
        {

        }

        public Entity(int id) : this(id, default)
        {

        }

        public Entity(int id, byte[] timeStamp) : base(id, timeStamp, Entity.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Schema { get; set; }
		
		public string Name { get; set; }
		
		public string Synonym { get; set; }
		
		public string IndexUrl { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Property> ListOfProperty { get; set; }

		[JsonIgnore]
		public List<RolePermission> ListOfRolePermission { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Schema.Validate() &&
					Name.Validate() &&
					Synonym.Validate() &&
					IndexUrl.Validate() &&
					IsActive.Validate();
        }
    }
}
