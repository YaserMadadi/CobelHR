using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class Subject : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "Subject", "Subject");

        #region Constructor
        public Subject() : this(0)
        {

        }

        public Subject(int id) : this(id, default)
        {

        }

        public Subject(int id, byte[] timeStamp) : base(id, timeStamp, Subject.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<IndividualDevelopmentPlan> ListOfIndividualDevelopmentPlan { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
