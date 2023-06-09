using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class Assessor : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "Assessor", "Assessor");

        #region Constructor
        public Assessor() : this(0)
        {

        }

        public Assessor(int id) : this(id, default)
        {

        }

        public Assessor(int id, byte[] timeStamp) : base(id, timeStamp, Assessor.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.Gender Gender { get; set; }
		
		public string FirstName { get; set; }
		
		public string LastName { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Assessment> ListOfAssessment { get; set; }

		[JsonIgnore]
		public List<AssessorConnectionLine> ListOfAssessorConnectionLine { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Gender.Validate() &&
					FirstName.Validate() &&
					LastName.Validate();
        }
    }
}
