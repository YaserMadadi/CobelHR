using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class MenuItem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "MenuItem", "MenuItem");

        #region Constructor
        public MenuItem() : this(0)
        {

        }

        public MenuItem(int id) : this(id, default)
        {

        }

        public MenuItem(int id, byte[] timeStamp) : base(id, timeStamp, MenuItem.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.Menu Menu { get; set; }
		
        public Core.MenuItemType MenuItemType { get; set; }
		
		public string Title { get; set; }
		
		public string URL { get; set; }
		
		public string Icon { get; set; }
		
        public int? Priority { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Badge> ListOfBadge { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Menu.Validate() &&
					MenuItemType.Validate() &&
					Title.Validate() &&
					URL.Validate() &&
					Icon.Validate() &&
					Priority.Validate();
        }
    }
}
