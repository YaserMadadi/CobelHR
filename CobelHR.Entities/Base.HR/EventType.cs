using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base.HR
{
    public class EventType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.HR", "EventType", "EventType");

        #region Constructor
        public EventType() : this(0)
        {

        }

        public EventType(int id) : this(id, default)
        {

        }

        public EventType(int id, byte[] timeStamp) : base(id, timeStamp, EventType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<EmployeeEvent> ListOfEmployeeEvent { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
