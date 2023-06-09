using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.LAD
{
    public class Conclusion : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("LAD", "Conclusion", "Conclusion");

        #region Constructor
        public Conclusion() : this(0)
        {

        }

        public Conclusion(int id) : this(id, default)
        {

        }

        public Conclusion(int id, byte[] timeStamp) : base(id, timeStamp, Conclusion.Informer)
        {

        }

        #endregion

        #region Properties

		
        public LAD.Assessment Assessment { get; set; }
		
        public LAD.ConclusionType ConclusionType { get; set; }
		
		public string Note { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Assessment.Validate() &&
					ConclusionType.Validate() &&
					Note.Validate();
        }
    }
}
