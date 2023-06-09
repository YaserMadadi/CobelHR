using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class Department : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "Department", "Department");

        #region Constructor
        public Department() : this(0)
        {

        }

        public Department(int id) : this(id, default)
        {

        }

        public Department(int id, byte[] timeStamp) : base(id, timeStamp, Department.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Unit> ListOfUnit { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
