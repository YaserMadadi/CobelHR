using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class EmployeeNotification : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "EmployeeNotification", "EmployeeNotification");

        #region Constructor
        public EmployeeNotification() : this(0)
        {

        }

        public EmployeeNotification(int id) : this(id, default)
        {

        }

        public EmployeeNotification(int id, byte[] timeStamp) : base(id, timeStamp, EmployeeNotification.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
		public string Title { get; set; }
		
		public string Content { get; set; }
		
		public DateTime? SendTime { get; set; }
		
		public DateTime? ViewTime { get; set; }
		
		public string Link { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Title.Validate() &&
					Content.Validate() &&
					SendTime.Validate() &&
					ViewTime.Validate() &&
					Link.Validate();
        }
    }
}
