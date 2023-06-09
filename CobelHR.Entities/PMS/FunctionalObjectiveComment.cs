using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class FunctionalObjectiveComment : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "FunctionalObjectiveComment", "FunctionalObjectiveComment");

        #region Constructor
        public FunctionalObjectiveComment() : this(0)
        {

        }

        public FunctionalObjectiveComment(int id) : this(id, default)
        {

        }

        public FunctionalObjectiveComment(int id, byte[] timeStamp) : base(id, timeStamp, FunctionalObjectiveComment.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.FunctionalObjective FunctionalObjective { get; set; }
		
		public string Comment { get; set; }
		
        public HR.Employee Commenter { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return FunctionalObjective.Validate();
        }
    }
}
