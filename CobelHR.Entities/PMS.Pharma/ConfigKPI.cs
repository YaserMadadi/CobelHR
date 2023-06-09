using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS.Pharma
{
    public class ConfigKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "ConfigKPI", "ConfigKPI");

        #region Constructor
        public ConfigKPI() : this(0)
        {

        }

        public ConfigKPI(int id) : this(id, default)
        {

        }

        public ConfigKPI(int id, byte[] timeStamp) : base(id, timeStamp, ConfigKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Pharma.ConfigObjective ConfigObjective { get; set; }
		
		public string Title { get; set; }
		
        public int? Weight { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return ConfigObjective.Validate() &&
					Title.Validate() &&
					Weight.Validate();
        }
    }
}
