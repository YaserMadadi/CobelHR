using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class MilitaryServiceInclusive : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "MilitaryServiceInclusive", "MilitaryServiceInclusive");

        #region Constructor
        public MilitaryServiceInclusive() : this(0)
        {

        }

        public MilitaryServiceInclusive(int id) : this(id, default)
        {

        }

        public MilitaryServiceInclusive(int id, byte[] timeStamp) : base(id, timeStamp, MilitaryServiceInclusive.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.MilitaryService MilitaryService { get; set; }
		
        public Base.InclusiveType InclusiveType { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return MilitaryService.Validate() &&
					InclusiveType.Validate();
        }
    }
}
