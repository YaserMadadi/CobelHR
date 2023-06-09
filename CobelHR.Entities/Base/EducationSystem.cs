using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class EducationSystem : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "EducationSystem", "EducationSystem");

        #region Constructor
        public EducationSystem() : this(0)
        {

        }

        public EducationSystem(int id) : this(id, default)
        {

        }

        public EducationSystem(int id, byte[] timeStamp) : base(id, timeStamp, EducationSystem.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<UniversityHistory> ListOfUniversityHistory { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
