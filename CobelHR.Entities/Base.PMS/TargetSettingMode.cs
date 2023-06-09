using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class TargetSettingMode : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "TargetSettingMode", "Target Setting Mode");

        #region Constructor
        public TargetSettingMode() : this(0)
        {

        }

        public TargetSettingMode(int id) : this(id, default)
        {

        }

        public TargetSettingMode(int id, byte[] timeStamp) : base(id, timeStamp, TargetSettingMode.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<TargetSetting> ListOfTargetSetting { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
