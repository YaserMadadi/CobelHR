using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class UniversityDegree : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "UniversityDegree", "UniversityDegree");

        #region Constructor
        public UniversityDegree() : this(0)
        {

        }

        public UniversityDegree(int id) : this(id, default)
        {

        }

        public UniversityDegree(int id, byte[] timeStamp) : base(id, timeStamp, UniversityDegree.Informer)
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
