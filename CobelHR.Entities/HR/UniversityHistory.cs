using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class UniversityHistory : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "UniversityHistory", "UniversityHistory");

        #region Constructor
        public UniversityHistory() : this(0)
        {

        }

        public UniversityHistory(int id) : this(id, default)
        {

        }

        public UniversityHistory(int id, byte[] timeStamp) : base(id, timeStamp, UniversityHistory.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.UniversityDegree UniversityDegree { get; set; }
		
        public Base.University University { get; set; }
		
        public Base.FieldOfStudy FieldOfStudy { get; set; }
		
        public Base.EducationSystem EducationSystem { get; set; }
		
        public Base.CertificationType CertificationType { get; set; }
		
		public DateTime? StartDate { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<UniversityTerminate> ListOfUniversityTerminate { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					UniversityDegree.Validate() &&
					University.Validate() &&
					FieldOfStudy.Validate() &&
					EducationSystem.Validate() &&
					CertificationType.Validate() &&
					StartDate.Validate();
        }
    }
}
