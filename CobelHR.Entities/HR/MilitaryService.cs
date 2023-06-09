using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class MilitaryService : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "MilitaryService", "MilitaryService");

        #region Constructor
        public MilitaryService() : this(0)
        {

        }

        public MilitaryService(int id) : this(id, default)
        {

        }

        public MilitaryService(int id, byte[] timeStamp) : base(id, timeStamp, MilitaryService.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.MilitaryServiceStatus MilitaryServiceStatus { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<MilitaryServiceExcemption> ListOfMilitaryServiceExcemption { get; set; }

		[JsonIgnore]
		public List<MilitaryServiceInclusive> ListOfMilitaryServiceInclusive { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					MilitaryServiceStatus.Validate();
        }
    }
}
