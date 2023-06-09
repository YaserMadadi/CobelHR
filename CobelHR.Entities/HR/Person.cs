using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;
using CobelHR.Entities.Core;

namespace CobelHR.Entities.HR
{
    public class Person : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Person", "Person");

        #region Constructor
        public Person() : this(0)
        {

        }

        public Person(int id) : this(id, default)
        {

        }

        public Person(int id, byte[] timeStamp) : base(id, timeStamp, Person.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string NationalCode { get; set; }
		
		public string EnglishFirstName { get; set; }
		
		public string EnglishLastName { get; set; }
		
		public string EnglishNickName { get; set; }
		
		public string PersianFirstName { get; set; }
		
		public string PersianLastName { get; set; }
		
		public string PersianNickName { get; set; }
		
        public Base.Gender Gender { get; set; }
		
		public string EnglishFatherName { get; set; }
		
		public string PersianFatherName { get; set; }
		
		public DateTime? DocumentedBirthDate { get; set; }
		
		public DateTime? RealBirthDate { get; set; }
		
        public Base.City BirthCity { get; set; }
		
        public Base.Religion Religion { get; set; }
		
        public Base.HealthStatus HealthStatus { get; set; }
		
        public Base.Country Nationality { get; set; }
		
		public string BirthCertificateNumber { get; set; }
		
		public string BirthCertificateSerialNumber { get; set; }
		
        public Base.HR.MaritalStatus MaritalStatus { get; set; }
		
        public int? ChildCount { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CoachingQuestionary> ListOfResponsiblePerson_CoachingQuestionary { get; set; }

		[JsonIgnore]
		public List<Employee> ListOfEmployee { get; set; }

		[JsonIgnore]
		public List<Habitancy> ListOfHabitancy { get; set; }

		[JsonIgnore]
		public List<LanguageAbility> ListOfLanguageAbility { get; set; }

		[JsonIgnore]
		public List<Log> ListOfLog { get; set; }

		[JsonIgnore]
		public List<MaritalInfo> ListOfMaritalInfo { get; set; }

		[JsonIgnore]
		public List<MilitaryService> ListOfMilitaryService { get; set; }

		[JsonIgnore]
		public List<Passport> ListOfPassport { get; set; }

		[JsonIgnore]
		public List<PersonCertificate> ListOfPersonCertificate { get; set; }

		[JsonIgnore]
		public List<PersonConnection> ListOfPersonConnection { get; set; }

		[JsonIgnore]
		public List<PersonDrivingLicense> ListOfPersonDrivingLicense { get; set; }

		[JsonIgnore]
		public List<Relative> ListOfPeson_Relative { get; set; }

		[JsonIgnore]
		public List<SchoolHistory> ListOfSchoolHistory { get; set; }

		[JsonIgnore]
		public List<UniversityHistory> ListOfUniversityHistory { get; set; }

		[JsonIgnore]
		public List<UserAccount> ListOfUserAccount { get; set; }

		[JsonIgnore]
		public List<WorkExperience> ListOfWorkExperience { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return NationalCode.Validate() &&
					EnglishFirstName.Validate() &&
					EnglishLastName.Validate() &&
					EnglishNickName.Validate() &&
					PersianFirstName.Validate() &&
					PersianLastName.Validate() &&
					PersianNickName.Validate() &&
					Gender.Validate() &&
					EnglishFatherName.Validate() &&
					PersianFatherName.Validate() &&
					DocumentedBirthDate.Validate() &&
					RealBirthDate.Validate() &&
					BirthCity.Validate() &&
					Religion.Validate() &&
					HealthStatus.Validate() &&
					Nationality.Validate() &&
					BirthCertificateNumber.Validate() &&
					BirthCertificateSerialNumber.Validate() &&
					MaritalStatus.Validate() &&
					ChildCount.Validate();
        }
    }
}
