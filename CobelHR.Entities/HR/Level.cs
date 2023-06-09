using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class Level : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Level", "Level");

        #region Constructor
        public Level() : this(0)
        {

        }

        public Level(int id) : this(id, default)
        {

        }

        public Level(int id, byte[] timeStamp) : base(id, timeStamp, Level.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<ObjectiveWeightNonOperational> ListOfObjectiveWeightNonOperational { get; set; }

		[JsonIgnore]
		public List<Position> ListOfPosition { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
