using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS.Pharma
{
    public class ConfigObjective : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "ConfigObjective", "ConfigObjective");

        #region Constructor
        public ConfigObjective() : this(0)
        {

        }

        public ConfigObjective(int id) : this(id, default)
        {

        }

        public ConfigObjective(int id, byte[] timeStamp) : base(id, timeStamp, ConfigObjective.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.Pharma.PharmaConfigTargetSetting ConfigTargetSetting { get; set; }
        
        public PMS.Pharma.ObjectiveType ObjectiveType { get; set; }
		
		public string Title { get; set; }
		
        public int? Weight { get; set; }
		
        //public int? TotalKPIWeight { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<ConfigKPI> ListOfConfigKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return ConfigTargetSetting.Validate() &&
                    Title.Validate() &&
                    Weight.Validate();// &&
					//TotalKPIWeight.Validate();
        }
    }
}
