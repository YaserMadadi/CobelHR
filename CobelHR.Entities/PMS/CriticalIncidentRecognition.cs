using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class CriticalIncidentRecognition : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CriticalIncidentRecognition", "CriticalIncidentRecognition");

        #region Constructor
        public CriticalIncidentRecognition() : this(0)
        {

        }

        public CriticalIncidentRecognition(int id) : this(id, default)
        {

        }

        public CriticalIncidentRecognition(int id, byte[] timeStamp) : base(id, timeStamp, CriticalIncidentRecognition.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.CriticalIncident CriticalIncident { get; set; }
		
		public DateTime? Time { get; set; }
		
        public HR.Employee Writer { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return CriticalIncident.Validate() &&
					Time.Validate() &&
					Writer.Validate();
        }
    }
}
