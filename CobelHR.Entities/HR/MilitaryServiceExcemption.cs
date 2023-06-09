using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class MilitaryServiceExcemption : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "MilitaryServiceExcemption", "MilitaryServiceExcemption");

        #region Constructor
        public MilitaryServiceExcemption() : this(0)
        {

        }

        public MilitaryServiceExcemption(int id) : this(id, default)
        {

        }

        public MilitaryServiceExcemption(int id, byte[] timeStamp) : base(id, timeStamp, MilitaryServiceExcemption.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.MilitaryService MilitaryService { get; set; }
		
        public Base.ExcemptionType ExcemptionType { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return MilitaryService.Validate() &&
					ExcemptionType.Validate();
        }
    }
}
