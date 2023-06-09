using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class Contract : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Contract", "Contract");

        #region Constructor
        public Contract() : this(0)
        {

        }

        public Contract(int id) : this(id, default)
        {

        }

        public Contract(int id, byte[] timeStamp) : base(id, timeStamp, Contract.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public Base.HR.ContractType ContractType { get; set; }
		
		public string Number { get; set; }
		
		public DateTime? FromDate { get; set; }
		
		public DateTime? ToDate { get; set; }
		
		public bool? IsSigned { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					ContractType.Validate() &&
					Number.Validate() &&
					FromDate.Validate() &&
					ToDate.Validate() &&
					IsSigned.Validate();
        }
    }
}
