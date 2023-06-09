using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class AssessmentType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "AssessmentType", "AssessmentType");

        #region Constructor
        public AssessmentType() : this(0)
        {

        }

        public AssessmentType(int id) : this(id, default)
        {

        }

        public AssessmentType(int id, byte[] timeStamp) : base(id, timeStamp, AssessmentType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Assessment> ListOfAssessment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
