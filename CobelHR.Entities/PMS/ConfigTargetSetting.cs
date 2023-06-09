using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class ConfigTargetSetting : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "ConfigTargetSetting", "ConfigTargetSetting");

        #region Constructor
        public ConfigTargetSetting() : this(0)
        {

        }

        public ConfigTargetSetting(int id) : this(id, default)
        {

        }

        public ConfigTargetSetting(int id, byte[] timeStamp) : base(id, timeStamp, ConfigTargetSetting.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.HR.PositionCategory PositionCategory { get; set; }
		
		public DateTime? FromDate { get; set; }
		
        public int? QuantitativeWeight { get; set; }
		
        public int? QualitativeWeight { get; set; }
		
        public int? QualitativeNonBehavioralWeight { get; set; }
		
        public int? QualitativeBehavioralWeight { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<ConfigQualitativeObjective> ListOfConfigQualitativeObjective { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return PositionCategory.Validate() &&
					FromDate.Validate() &&
					QuantitativeWeight.Validate() &&
					QualitativeWeight.Validate() &&
					QualitativeNonBehavioralWeight.Validate() &&
					QualitativeBehavioralWeight.Validate();
        }
    }
}
