using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class BadgeType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "BadgeType", "BadgeType");

        #region Constructor
        public BadgeType() : this(0)
        {

        }

        public BadgeType(int id) : this(id, default)
        {

        }

        public BadgeType(int id, byte[] timeStamp) : base(id, timeStamp, BadgeType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Badge> ListOfBadge { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
