using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    /// <summary>
    /// test
    /// </summary>
    public class Country : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Country", "Country");

        #region Constructor
        public Country() : this(0)
        {

        }

        public Country(int id) : this(id, default)
        {

        }

        public Country(int id, byte[] timeStamp) : base(id, timeStamp, Country.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string EnglishTitle { get; set; }
		
		public string PersianTitle { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Person> ListOfNationality_Person { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return EnglishTitle.Validate() &&
					PersianTitle.Validate() &&
					IsActive.Validate();
        }
    }
}
