using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class Badge : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Badge", "Badge");

        #region Constructor
        public Badge() : this(0)
        {

        }

        public Badge(int id) : this(id, default)
        {

        }

        public Badge(int id, byte[] timeStamp) : base(id, timeStamp, Badge.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.MenuItem MenuItem { get; set; }
		
        public Core.BadgeType BadgeType { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return MenuItem.Validate() &&
					BadgeType.Validate();
        }
    }
}
