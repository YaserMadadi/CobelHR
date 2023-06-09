using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class HabitancyType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "HabitancyType", "HabitancyType");

        #region Constructor
        public HabitancyType() : this(0)
        {

        }

        public HabitancyType(int id) : this(id, default)
        {

        }

        public HabitancyType(int id, byte[] timeStamp) : base(id, timeStamp, HabitancyType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Habitancy> ListOfHabitancy { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
