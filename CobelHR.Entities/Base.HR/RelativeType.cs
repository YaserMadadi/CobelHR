using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class RelativeType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "RelativeType", "RelativeType");

        #region Constructor
        public RelativeType() : this(0)
        {

        }

        public RelativeType(int id) : this(id, default)
        {

        }

        public RelativeType(int id, byte[] timeStamp) : base(id, timeStamp, RelativeType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Relative> ListOfRelationType_Relative { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
