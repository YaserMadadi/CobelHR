using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class QualitativeAppraise : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "QualitativeAppraise", "QualitativeAppraise");

        #region Constructor
        public QualitativeAppraise() : this(0)
        {

        }

        public QualitativeAppraise(int id) : this(id, default)
        {

        }

        public QualitativeAppraise(int id, byte[] timeStamp) : base(id, timeStamp, QualitativeAppraise.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.QualitativeKPI QualitativeKPI { get; set; }
		
		public DateTime? Date { get; set; }
		
        public HR.Employee Appraiser { get; set; }
		
        public Base.PMS.AppraiseType AppraiseType { get; set; }
		
        public int? Actual { get; set; }
		
        public decimal? Score { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return QualitativeKPI.Validate() &&
					Date.Validate() &&
					Appraiser.Validate() &&
					AppraiseType.Validate() &&
					Actual.Validate() &&
					Score.Validate();
        }
    }
}
