using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class Gender : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Gender", "Gender");

        #region Constructor
        public Gender() : this(0)
        {

        }

        public Gender(int id) : this(id, default)
        {

        }

        public Gender(int id, byte[] timeStamp) : base(id, timeStamp, Gender.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string PersianTitle { get; set; }
		
		public string EnglishTitle { get; set; }
		
		public string PersianPreFix { get; set; }
		
		public string EnglishPreFix { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Assessor> ListOfAssessor { get; set; }

		[JsonIgnore]
		public List<Coach> ListOfCoach { get; set; }

		[JsonIgnore]
		public List<Person> ListOfPerson { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return PersianTitle.Validate() &&
					EnglishTitle.Validate() &&
					PersianPreFix.Validate() &&
					EnglishPreFix.Validate();
        }
    }
}
