using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class MaritalInfo : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "MaritalInfo", "MaritalInfo");

        #region Constructor
        public MaritalInfo() : this(0)
        {

        }

        public MaritalInfo(int id) : this(id, default)
        {

        }

        public MaritalInfo(int id, byte[] timeStamp) : base(id, timeStamp, MaritalInfo.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
		public DateTime? MarriageDate { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					MarriageDate.Validate();
        }
    }
}
