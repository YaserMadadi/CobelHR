using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class Menu : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Menu", "Menu");

        #region Constructor
        public Menu() : this(0)
        {

        }

        public Menu(int id) : this(id, default)
        {

        }

        public Menu(int id, byte[] timeStamp) : base(id, timeStamp, Menu.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Core.SubSystem SubSystem { get; set; }
		
		public string Title { get; set; }
		
		public string Icon { get; set; }
		
        public int? Priority { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MenuItem> ListOfMenuItem { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return SubSystem.Validate() &&
					Title.Validate() &&
					Icon.Validate() &&
					Priority.Validate();
        }
    }
}
