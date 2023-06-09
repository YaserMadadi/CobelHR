using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.LAD;

namespace CobelHR.Entities.LAD
{
    public class Coaching : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "Coaching", "Coaching");

        #region Constructor
        public Coaching() : this(0)
        {

        }

        public Coaching(int id) : this(id, default)
        {

        }

        public Coaching(int id, byte[] timeStamp) : base(id, timeStamp, Coaching.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Employee Employee { get; set; }
		
		public DateTime? AgreementDate { get; set; }
		
		public string Porpuse { get; set; }
		
        public LAD.Coach Coach { get; set; }
		
        public int? SessionCount { get; set; }
		
        public int? Effectiveness { get; set; }
		
        public int? RunnedSessionCount { get; set; }
		
		public bool? IsFinished { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AssessmentCoaching> ListOfAssessmentCoaching { get; set; }

		[JsonIgnore]
		public List<CoachingSession> ListOfCoachingSession { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Employee.Validate() &&
					AgreementDate.Validate() &&
					Porpuse.Validate() &&
					Coach.Validate() &&
					SessionCount.Validate() &&
					Effectiveness.Validate() &&
					RunnedSessionCount.Validate() &&
					IsFinished.Validate();
        }
    }
}
