using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class FunctionalKPIComment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FunctionalKPIComment", "FunctionalKPIComment");

        #region Constructor
        public FunctionalKPIComment() : this(0)
        {

        }

        public FunctionalKPIComment(int id) : this(id, default)
        {

        }

        public FunctionalKPIComment(int id, byte[] timeStamp) : base(id, timeStamp, FunctionalKPIComment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.FunctionalKPI FunctionalKPI { get; set; }
		
		public string Comment { get; set; }
		
        public HR.Employee Commenter { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return FunctionalKPI.Validate();
        }
    }
}
