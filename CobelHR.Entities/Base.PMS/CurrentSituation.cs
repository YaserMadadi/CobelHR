using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.Base.PMS
{
    public class CurrentSituation : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base.PMS", "CurrentSituation", "CurrentSituation");

        #region Constructor
        public CurrentSituation() : this(0)
        {

        }

        public CurrentSituation(int id) : this(id, default)
        {

        }

        public CurrentSituation(int id, byte[] timeStamp) : base(id, timeStamp, CurrentSituation.Informer)
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
