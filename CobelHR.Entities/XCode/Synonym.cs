using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.XCode
{
    public class Synonym : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("XCode", "Synonym", "Synonym");

        #region Constructor
        public Synonym() : this(0)
        {

        }

        public Synonym(int id) : this(id, default)
        {

        }

        public Synonym(int id, byte[] timeStamp) : base(id, timeStamp, Synonym.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Schema { get; set; }
		
		public string Name { get; set; }
		
		public string Value { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Schema.Validate() &&
					Name.Validate() &&
					Value.Validate();
        }
    }
}
