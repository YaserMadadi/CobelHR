using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class InclusiveType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "InclusiveType", "InclusiveType");

        #region Constructor
        public InclusiveType() : this(0)
        {

        }

        public InclusiveType(int id) : this(id, default)
        {

        }

        public InclusiveType(int id, byte[] timeStamp) : base(id, timeStamp, InclusiveType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MilitaryServiceInclusive> ListOfMilitaryServiceInclusive { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
