using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class UniversityTerminate : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "UniversityTerminate", "UniversityTerminate");

        #region Constructor
        public UniversityTerminate() : this(0)
        {

        }

        public UniversityTerminate(int id) : this(id, default)
        {

        }

        public UniversityTerminate(int id, byte[] timeStamp) : base(id, timeStamp, UniversityTerminate.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.UniversityHistory UniversityHistory { get; set; }
		
		public DateTime? FinishedDate { get; set; }
		
        public decimal? Average { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return UniversityHistory.Validate() &&
					FinishedDate.Validate() &&
					Average.Validate();
        }
    }
}
