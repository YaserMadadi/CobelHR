using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class MeasurementUnit : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "MeasurementUnit", "MeasurementUnit");

        #region Constructor
        public MeasurementUnit() : this(0)
        {

        }

        public MeasurementUnit(int id) : this(id, default)
        {

        }

        public MeasurementUnit(int id, byte[] timeStamp) : base(id, timeStamp, MeasurementUnit.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<FunctionalKPI> ListOfFunctionalKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
