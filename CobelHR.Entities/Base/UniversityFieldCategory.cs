using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Base;

namespace CobelHR.Entities.Base
{
    public class UniversityFieldCategory : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "UniversityFieldCategory", "UniversityFieldCategory");

        #region Constructor
        public UniversityFieldCategory() : this(0)
        {

        }

        public UniversityFieldCategory(int id) : this(id, default)
        {

        }

        public UniversityFieldCategory(int id, byte[] timeStamp) : base(id, timeStamp, UniversityFieldCategory.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
        public int? Code { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<FieldOfStudy> ListOfFieldOfStudy { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					Code.Validate() &&
					IsActive.Validate();
        }
    }
}
