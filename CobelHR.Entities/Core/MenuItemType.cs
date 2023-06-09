using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class MenuItemType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "MenuItemType", "MenuItemType");

        #region Constructor
        public MenuItemType() : this(0)
        {

        }

        public MenuItemType(int id) : this(id, default)
        {

        }

        public MenuItemType(int id, byte[] timeStamp) : base(id, timeStamp, MenuItemType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MenuItem> ListOfMenuItem { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
