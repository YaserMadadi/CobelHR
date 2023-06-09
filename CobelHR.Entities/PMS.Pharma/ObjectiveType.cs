using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS.Pharma
{
    public class ObjectiveType : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS.Pharma", "ObjectiveType", "ObjectiveType");

        #region Constructor
        public ObjectiveType() : this(0)
        {

        }

        public ObjectiveType(int id) : this(id, default)
        {

        }

        public ObjectiveType(int id, byte[] timeStamp) : base(id, timeStamp, ObjectiveType.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<Objective> ListOfObjective { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
