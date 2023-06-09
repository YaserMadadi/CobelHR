using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class ConclusionType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "ConclusionType", "ConclusionType");

        #region Constructor
        public ConclusionType() : this(0)
        {

        }

        public ConclusionType(int id) : this(id, default)
        {

        }

        public ConclusionType(int id, byte[] timeStamp) : base(id, timeStamp, ConclusionType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Conclusion> ListOfConclusion { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
