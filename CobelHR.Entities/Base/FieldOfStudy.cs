using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class FieldOfStudy : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "FieldOfStudy", "FieldOfStudy");

        #region Constructor
        public FieldOfStudy() : this(0)
        {

        }

        public FieldOfStudy(int id) : this(id, default)
        {

        }

        public FieldOfStudy(int id, byte[] timeStamp) : base(id, timeStamp, FieldOfStudy.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.UniversityFieldCategory UniversityFieldCategory { get; set; }
		
		public string Major { get; set; }
		
		public string Minor { get; set; }
		
        public int? Code { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<UniversityHistory> ListOfUniversityHistory { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return UniversityFieldCategory.Validate() &&
					Major.Validate() &&
					Minor.Validate() &&
					Code.Validate() &&
					IsActive.Validate();
        }
    }
}
