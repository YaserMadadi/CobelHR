using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class Coach : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "Coach", "Coach");

        #region Constructor
        public Coach() : this(0)
        {

        }

        public Coach(int id) : this(id, default)
        {

        }

        public Coach(int id, byte[] timeStamp) : base(id, timeStamp, Coach.Informer)
        {

        }

        #endregion

        #region Properties

		
        public Base.Gender Gender { get; set; }
		
		public string FirstName { get; set; }
		
		public string LastName { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<CoachConnectionLine> ListOfCoachConnectionLine { get; set; }

		[JsonIgnore]
		public List<Coaching> ListOfCoaching { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Gender.Validate() &&
					FirstName.Validate() &&
					LastName.Validate();
        }
    }
}
