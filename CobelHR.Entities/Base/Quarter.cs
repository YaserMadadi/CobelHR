using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.Base;

namespace CobelHR.Entities.Base
{
    public class Quarter : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Quarter", "Quarter");

        #region Constructor
        public Quarter() : this(0)
        {

        }

        public Quarter(int id) : this(id, default)
        {

        }

        public Quarter(int id, byte[] timeStamp) : base(id, timeStamp, Quarter.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<YearQuarter> ListOfYearQuarter { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
