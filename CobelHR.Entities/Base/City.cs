using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;
using CobelHR.Entities.Base;

namespace CobelHR.Entities.Base
{
    public class City : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "City", "City");

        #region Constructor
        public City() : this(0)
        {

        }

        public City(int id) : this(id, default)
        {

        }

        public City(int id, byte[] timeStamp) : base(id, timeStamp, City.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public Base.Province Province { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Habitancy> ListOfHabitancy { get; set; }

		[JsonIgnore]
		public List<Person> ListOfBirthCity_Person { get; set; }

		[JsonIgnore]
		public List<University> ListOfUniversity { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Province.Validate() &&
					IsActive.Validate();
        }
    }
}
