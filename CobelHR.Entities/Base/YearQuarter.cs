using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.Base
{
    public class YearQuarter : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "YearQuarter", "YearQuarter");

        #region Constructor
        public YearQuarter() : this(0)
        {

        }

        public YearQuarter(int id) : this(id, default)
        {

        }

        public YearQuarter(int id, byte[] timeStamp) : base(id, timeStamp, YearQuarter.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public Base.Year Year { get; set; }
		
        public Base.Quarter Quarter { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AssessmentTraining> ListOfDeadLine_AssessmentTraining { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Year.Validate() &&
					Quarter.Validate();
        }
    }
}
