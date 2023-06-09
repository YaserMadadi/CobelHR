using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.Core
{
    public class Log : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Core", "Log", "Log");

        #region Constructor
        public Log() : this(0)
        {

        }

        public Log(int id) : this(id, default)
        {

        }

        public Log(int id, byte[] timeStamp) : base(id, timeStamp, Log.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string EntityName { get; set; }
		
        public int? RecordID { get; set; }
		
        public HR.Person Person { get; set; }
		
		public DateTime? EffectDate { get; set; }
		
		public string OldValue { get; set; }
		
		public string NewValue { get; set; }
		
		public string ActionMode { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return EntityName.Validate() &&
					RecordID.Validate() &&
					Person.Validate() &&
					EffectDate.Validate() &&
					OldValue.Validate() &&
					NewValue.Validate() &&
					ActionMode.Validate();
        }
    }
}
