using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.Base
{
    public class Language : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("Base", "Language", "Language");

        #region Constructor
        public Language() : this(0)
        {

        }

        public Language(int id) : this(id, default)
        {

        }

        public Language(int id, byte[] timeStamp) : base(id, timeStamp, Language.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<LanguageAbility> ListOfLanguageAbility { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
