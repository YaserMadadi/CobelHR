using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class TargetSettingPhase : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "TargetSettingPhase", "Target Setting Phase");

        #region Constructor
        public TargetSettingPhase() : this(0)
        {

        }

        public TargetSettingPhase(int id) : this(id, default)
        {

        }

        public TargetSettingPhase(int id, byte[] timeStamp) : base(id, timeStamp, TargetSettingPhase.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.Year Year { get; set; }

        public Base.PMS.TargetSettingType TargetSettingType { get; set; }

        public Base.PMS.TargetSettingMode TargetSettingMode { get; set; }

        #endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Year.Validate() &&
					TargetSettingType.Validate() &&
					TargetSettingMode.Validate();
        }
    }
}
