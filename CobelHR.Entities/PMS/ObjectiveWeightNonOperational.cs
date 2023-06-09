using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class ObjectiveWeightNonOperational : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "ObjectiveWeightNonOperational", "ObjectiveWeightNonOperational");

        #region Constructor
        public ObjectiveWeightNonOperational() : this(0)
        {

        }

        public ObjectiveWeightNonOperational(int id) : this(id, default)
        {

        }

        public ObjectiveWeightNonOperational(int id, byte[] timeStamp) : base(id, timeStamp, ObjectiveWeightNonOperational.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Level Level { get; set; }
		
        public int? FunctionalWeight { get; set; }
		
        public int? BehavioralWeight { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Level.Validate() &&
					FunctionalWeight.Validate() &&
					BehavioralWeight.Validate();
        }
    }
}
