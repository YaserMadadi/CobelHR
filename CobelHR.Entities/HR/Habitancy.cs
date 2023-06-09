using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class Habitancy : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Habitancy", "Habitancy");

        #region Constructor
        public Habitancy() : this(0)
        {

        }

        public Habitancy(int id) : this(id, default)
        {

        }

        public Habitancy(int id, byte[] timeStamp) : base(id, timeStamp, Habitancy.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.HabitancyType HabitancyType { get; set; }
		
        public Base.City City { get; set; }
		
		public string Address { get; set; }
		
		public string PostalCode { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					HabitancyType.Validate() &&
					City.Validate() &&
					Address.Validate() &&
					PostalCode.Validate();
        }
    }
}
