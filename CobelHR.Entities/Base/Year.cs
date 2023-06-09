using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;
using CobelHR.Entities.Base;

namespace CobelHR.Entities.Base
{
    public class Year : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Year", "Year");

        #region Constructor
        public Year() : this(0)
        {

        }

        public Year(int id) : this(id, default)
        {

        }

        public Year(int id, byte[] timeStamp) : base(id, timeStamp, Year.Informer)
        {

        }

        #endregion

        #region Properties

		
        public int? YearTitle { get; set; }
		
		public string Description { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<TargetSetting> ListOfTargetSetting { get; set; }

		[JsonIgnore]
		public List<YearQuarter> ListOfYearQuarter { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return YearTitle.Validate() &&
					IsActive.Validate();
        }
    }
}
