using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.Core
{
    public class SubSystem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "SubSystem", "SubSystem");

        #region Constructor
        public SubSystem() : this(0)
        {

        }

        public SubSystem(int id) : this(id, default)
        {

        }

        public SubSystem(int id, byte[] timeStamp) : base(id, timeStamp, SubSystem.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public string Icon { get; set; }
		
        public int? Priority { get; set; }

        public bool? IsActive { get; set; }

        #endregion

        #region    List Of Related Entities

        [JsonIgnore]
		public List<Menu> ListOfMenu { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Icon.Validate() &&
					Priority.Validate();
        }
    }
}
