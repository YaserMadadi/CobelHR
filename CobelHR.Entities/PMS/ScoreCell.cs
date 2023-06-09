using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.PMS;

namespace CobelHR.Entities.PMS
{
    public class ScoreCell : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "ScoreCell", "ScoreCell");

        #region Constructor
        public ScoreCell() : this(0)
        {

        }

        public ScoreCell(int id) : this(id, default)
        {

        }

        public ScoreCell(int id, byte[] timeStamp) : base(id, timeStamp, ScoreCell.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string CellNumber { get; set; }
		
        public decimal? Min_X { get; set; }
		
        public decimal? Max_X { get; set; }
		
        public decimal? Min_Y { get; set; }
		
        public decimal? Max_Y { get; set; }
		
        public decimal? Min_Pi { get; set; }
		
        public decimal? Max_Pi { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<AppraiseResult> ListOfAppraiseResult { get; set; }

		[JsonIgnore]
		public List<CellAction> ListOfCellAction { get; set; }

		[JsonIgnore]
		public List<FinalAppraise> ListOfFinalAppraise { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return CellNumber.Validate() &&
					Min_X.Validate() &&
					Max_X.Validate() &&
					Min_Y.Validate() &&
					Max_Y.Validate() &&
					Min_Pi.Validate() &&
					Max_Pi.Validate();
        }
    }
}
