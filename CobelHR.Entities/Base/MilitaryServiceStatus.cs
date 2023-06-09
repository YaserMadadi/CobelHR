using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class MilitaryServiceStatus : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "MilitaryServiceStatus", "MilitaryServiceStatus");

        #region Constructor
        public MilitaryServiceStatus() : this(0)
        {

        }

        public MilitaryServiceStatus(int id) : this(id, default)
        {

        }

        public MilitaryServiceStatus(int id, byte[] timeStamp) : base(id, timeStamp, MilitaryServiceStatus.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MilitaryService> ListOfMilitaryService { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate();
        }
    }
}
