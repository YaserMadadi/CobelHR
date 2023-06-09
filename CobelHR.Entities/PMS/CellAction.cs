using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.PMS
{
    public class CellAction : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("PMS", "CellAction", "CellAction");

        #region Constructor
        public CellAction() : this(0)
        {

        }

        public CellAction(int id) : this(id, default)
        {

        }

        public CellAction(int id, byte[] timeStamp) : base(id, timeStamp, CellAction.Informer)
        {

        }

        #endregion

        #region Properties

		
        public PMS.ScoreCell ScoreCell { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return ScoreCell.Validate();
        }
    }
}
