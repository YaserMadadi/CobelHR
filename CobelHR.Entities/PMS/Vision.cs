using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class Vision : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "Vision", "Vision");

        #region Constructor
        public Vision() : this(0)
        {

        }

        public Vision(int id) : this(id, default)
        {

        }

        public Vision(int id, byte[] timeStamp) : base(id, timeStamp, Vision.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
        public HR.Position Position { get; set; }
		
		public string Title { get; set; }
		
		public DateTime? Date { get; set; }
		
		public bool? IsApprovedByEmployee { get; set; }
		
		public bool? IsApprovedByDirectManager { get; set; }
		
		public bool? IsApprovedByBUHead { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<IndividualDevelopmentPlan> ListOfIndividualDevelopmentPlan { get; set; }

		[JsonIgnore]
		public List<VisionApproved> ListOfVisionApproved { get; set; }

		[JsonIgnore]
		public List<VisionComment> ListOfVisionComment { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					Position.Validate() &&
					Title.Validate() &&
					Date.Validate() &&
					IsApprovedByEmployee.Validate() &&
					IsApprovedByDirectManager.Validate() &&
					IsApprovedByBUHead.Validate();
        }
    }
}
