using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class SchoolHistory : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "SchoolHistory", "SchoolHistory");

        #region Constructor
        public SchoolHistory() : this(0)
        {

        }

        public SchoolHistory(int id) : this(id, default)
        {

        }

        public SchoolHistory(int id, byte[] timeStamp) : base(id, timeStamp, SchoolHistory.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.SchoolLevel SchoolLevel { get; set; }
		
		public string SchoolName { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					SchoolLevel.Validate() &&
					SchoolName.Validate();
        }
    }
}
