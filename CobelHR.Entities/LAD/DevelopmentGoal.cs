using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class DevelopmentGoal : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "DevelopmentGoal", "DevelopmentGoal");

        #region Constructor
        public DevelopmentGoal() : this(0)
        {

        }

        public DevelopmentGoal(int id) : this(id, default)
        {

        }

        public DevelopmentGoal(int id, byte[] timeStamp) : base(id, timeStamp, DevelopmentGoal.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
		public string Note { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					Note.Validate();
        }
    }
}
