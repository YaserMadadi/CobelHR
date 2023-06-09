using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class PositionCategory : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "PositionCategory", "PositionCategory");

        #region Constructor
        public PositionCategory() : this(0)
        {

        }

        public PositionCategory(int id) : this(id, default)
        {

        }

        public PositionCategory(int id, byte[] timeStamp) : base(id, timeStamp, PositionCategory.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

        #endregion

        #region    List Of Related Entities

        [JsonIgnore]
		public List<ConfigTargetSetting> ListOfConfigTargetSetting { get; set; }

        [JsonIgnore]
		public List<AppraisalApproverConfig> ListOfDepartmentCategory_AppraisalApproverConfig { get; set; }

		[JsonIgnore]
		public List<Position> ListOfPosition { get; set; }

		[JsonIgnore]
		public List<Unit> ListOfUnit { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
