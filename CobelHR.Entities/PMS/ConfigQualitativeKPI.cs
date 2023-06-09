using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class ConfigQualitativeKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "ConfigQualitativeKPI", "ConfigQualitativeKPI");

        #region Constructor
        public ConfigQualitativeKPI() : this(0)
        {

        }

        public ConfigQualitativeKPI(int id) : this(id, default)
        {

        }

        public ConfigQualitativeKPI(int id, byte[] timeStamp) : base(id, timeStamp, ConfigQualitativeKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.ConfigQualitativeObjective ConfigQualitativeObjective { get; set; }
		
		public string Title { get; set; }
		
        public int? Weight { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return ConfigQualitativeObjective.Validate() &&
					Title.Validate() &&
					Weight.Validate();
        }
    }
}
