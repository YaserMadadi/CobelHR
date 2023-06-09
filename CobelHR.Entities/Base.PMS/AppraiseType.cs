using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class AppraiseType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "AppraiseType", "AppraiseType");

        #region Constructor
        public AppraiseType() : this(0)
        {

        }

        public AppraiseType(int id) : this(id, default)
        {

        }

        public AppraiseType(int id, byte[] timeStamp) : base(id, timeStamp, AppraiseType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AppraiseResult> ListOfAppraiseResult { get; set; }

		[JsonIgnore]
		public List<BehavioralAppraise> ListOfBehavioralAppraise { get; set; }

		[JsonIgnore]
		public List<FunctionalAppraise> ListOfFunctionalAppraise { get; set; }

		[JsonIgnore]
		public List<QualitativeAppraise> ListOfQualitativeAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
