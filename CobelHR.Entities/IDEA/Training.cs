using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.IDEA
{
    public class Training : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("IDEA", "Training", "Training");

        #region Constructor
        public Training() : this(0)
        {

        }

        public Training(int id) : this(id, default)
        {

        }

        public Training(int id, byte[] timeStamp) : base(id, timeStamp, Training.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public IDEA.Course Course { get; set; }
		
        public int? ExecutiveYear { get; set; }
		
		public bool? TrainingStatus { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Course.Validate() &&
					ExecutiveYear.Validate() &&
					TrainingStatus.Validate();
        }
    }
}
