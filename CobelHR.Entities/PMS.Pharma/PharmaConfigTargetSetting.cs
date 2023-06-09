using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS.Pharma
{
    public class PharmaConfigTargetSetting : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "ConfigTargetSetting", "ConfigTargetSetting");

        #region Constructor
        public PharmaConfigTargetSetting() : this(0)
        {

        }

        public PharmaConfigTargetSetting(int id) : this(id, default)
        {

        }

        public PharmaConfigTargetSetting(int id, byte[] timeStamp) : base(id, timeStamp, PharmaConfigTargetSetting.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.HR.PositionCategory PositionCategory { get; set; }
		
		public DateTime? FromDate { get; set; }
		
        
        public decimal? DivisionWeight { get; set; }
        
        public decimal? DivisionFixedTotalWeight { get; set; }

        public decimal? DivisionNonFixedTotalWeight { get; set; }
        
        
        public decimal? FunctionWeight { get; set; }

        public decimal? FunctionFixedTotalWeight { get; set; }
        
        public decimal? FunctionNonFixedTotalWeight { get; set; }

        public decimal? IndividualWeight { get; set; }

        public decimal? IndividualGrowWeight { get; set; }

        public decimal? IndividualFixedTotalWeight { get; set; }

        public decimal? IndividualNonFixedTotalWeight { get; set; }


		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<ConfigObjective> ListOfConfigObjective { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return PositionCategory.Validate() &&
					FromDate.Validate() &&
                    DivisionWeight.Validate() &&
                    DivisionFixedTotalWeight.Validate() &&
                    DivisionNonFixedTotalWeight.Validate() &&
                    FunctionWeight.Validate() &&
                    FunctionFixedTotalWeight.Validate() &&
                    FunctionNonFixedTotalWeight.Validate() &&
                    IndividualWeight.Validate() &&
                    IndividualGrowWeight.Validate() &&
                    IndividualFixedTotalWeight.Validate() &&
                    IndividualNonFixedTotalWeight.Validate();
        }
    }
}
