using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class ConfigQualitativeObjective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "ConfigQualitativeObjective", "ConfigQualitativeObjective");

        #region Constructor
        public ConfigQualitativeObjective() : this(0)
        {

        }

        public ConfigQualitativeObjective(int id) : this(id, default)
        {

        }

        public ConfigQualitativeObjective(int id, byte[] timeStamp) : base(id, timeStamp, ConfigQualitativeObjective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.ConfigTargetSetting ConfigTargetSetting { get; set; }
		
		public string Title { get; set; }
		
        public int? Weight { get; set; }
		
        public int? TotalKPIWeight { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<ConfigQualitativeKPI> ListOfConfigQualitativeKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return ConfigTargetSetting.Validate() &&
					Title.Validate() &&
					Weight.Validate() &&
					TotalKPIWeight.Validate();
        }
    }
}
