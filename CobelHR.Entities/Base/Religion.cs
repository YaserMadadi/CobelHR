using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class Religion : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Religion", "Religion");

        #region Constructor
        public Religion() : this(0)
        {

        }

        public Religion(int id) : this(id, default)
        {

        }

        public Religion(int id, byte[] timeStamp) : base(id, timeStamp, Religion.Informer)
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
		public List<Person> ListOfPerson { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return EnglishTitle.Validate() &&
					PersianTitle.Validate() &&
					IsActive.Validate();
        }
    }
}
