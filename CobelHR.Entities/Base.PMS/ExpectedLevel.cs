using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class ExpectedLevel : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "ExpectedLevel", "ExpectedLevel");

        #region Constructor
        public ExpectedLevel() : this(0)
        {

        }

        public ExpectedLevel(int id) : this(id, default)
        {

        }

        public ExpectedLevel(int id, byte[] timeStamp) : base(id, timeStamp, ExpectedLevel.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<BehavioralObjective> ListOfBehavioralObjective { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
