using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.IDEA;

namespace CobelHR.Entities.IDEA
{
    public class Course : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("IDEA", "Course", "Course");

        #region Constructor
        public Course() : this(0)
        {

        }

        public Course(int id) : this(id, default)
        {

        }

        public Course(int id, byte[] timeStamp) : base(id, timeStamp, Course.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Training> ListOfTraining { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
