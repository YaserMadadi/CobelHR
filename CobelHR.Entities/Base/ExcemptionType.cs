using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class ExcemptionType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "ExcemptionType", "ExcemptionType");

        #region Constructor
        public ExcemptionType() : this(0)
        {

        }

        public ExcemptionType(int id) : this(id, default)
        {

        }

        public ExcemptionType(int id, byte[] timeStamp) : base(id, timeStamp, ExcemptionType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MilitaryServiceExcemption> ListOfMilitaryServiceExcemption { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate();
        }
    }
}
