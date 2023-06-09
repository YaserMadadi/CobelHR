using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class EmployeeEvent : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "EmployeeEvent", "EmployeeEvent");

        #region Constructor
        public EmployeeEvent() : this(0)
        {

        }

        public EmployeeEvent(int id) : this(id, default)
        {

        }

        public EmployeeEvent(int id, byte[] timeStamp) : base(id, timeStamp, EmployeeEvent.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
		public DateTime? Date { get; set; }
		
        public string Time { get; set; }
		
        public Base.HR.EventType EventType { get; set; }
		
		public string Title { get; set; }
		
		public string Content { get; set; }
		
		public string Link { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Date.Validate() &&
					Time.Validate() &&
					EventType.Validate() &&
					Title.Validate() &&
					Content.Validate() &&
					Link.Validate();
        }
    }
}
