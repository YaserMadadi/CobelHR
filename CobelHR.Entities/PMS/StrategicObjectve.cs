using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class StrategicObjectve : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "StrategicObjectve", "StrategicObjectve");

        #region Constructor
        public StrategicObjectve() : this(0)
        {

        }

        public StrategicObjectve(int id) : this(id, default)
        {

        }

        public StrategicObjectve(int id, byte[] timeStamp) : base(id, timeStamp, StrategicObjectve.Informer)
        {

        }

        #endregion

        #region Properties

		
		public DateTime? FromDate { get; set; }
		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return FromDate.Validate() &&
					Title.Validate() &&
					IsActive.Validate();
        }
    }
}
