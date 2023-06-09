using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class CriticalIncident : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CriticalIncident", "CriticalIncident");

        #region Constructor
        public CriticalIncident() : this(0)
        {

        }

        public CriticalIncident(int id) : this(id, default)
        {

        }

        public CriticalIncident(int id, byte[] timeStamp) : base(id, timeStamp, CriticalIncident.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public PMS.CriticalIncidentType CriticalIncidentType { get; set; }
		
		public DateTime? IssueDate { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CriticalIncidentRecognition> ListOfCriticalIncidentRecognition { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					CriticalIncidentType.Validate() &&
					IssueDate.Validate();
        }
    }
}
