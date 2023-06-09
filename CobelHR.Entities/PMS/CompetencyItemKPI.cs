using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class CompetencyItemKPI : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CompetencyItemKPI", "CompetencyItemKPI");

        #region Constructor
        public CompetencyItemKPI() : this(0)
        {

        }

        public CompetencyItemKPI(int id) : this(id, default)
        {

        }

        public CompetencyItemKPI(int id, byte[] timeStamp) : base(id, timeStamp, CompetencyItemKPI.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.CompetencyItem CompetencyItem { get; set; }
		
		public string Title { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<BehavioralKPI> ListOfBehavioralKPI { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return CompetencyItem.Validate() &&
					Title.Validate();
        }
    }
}
