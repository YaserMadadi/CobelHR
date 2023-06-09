using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class ContractType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "ContractType", "ContractType");

        #region Constructor
        public ContractType() : this(0)
        {

        }

        public ContractType(int id) : this(id, default)
        {

        }

        public ContractType(int id, byte[] timeStamp) : base(id, timeStamp, ContractType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Contract> ListOfContract { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
