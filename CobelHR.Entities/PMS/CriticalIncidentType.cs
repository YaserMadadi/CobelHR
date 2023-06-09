using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class CriticalIncidentType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CriticalIncidentType", "CriticalIncidentType");

        #region Constructor
        public CriticalIncidentType() : this(0)
        {

        }

        public CriticalIncidentType(int id) : this(id, default)
        {

        }

        public CriticalIncidentType(int id, byte[] timeStamp) : base(id, timeStamp, CriticalIncidentType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CriticalIncident> ListOfCriticalIncident { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
