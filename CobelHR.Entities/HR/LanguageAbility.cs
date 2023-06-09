using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;

namespace CobelHR.Entities.HR
{
    public class LanguageAbility : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "LanguageAbility", "LanguageAbility");

        #region Constructor
        public LanguageAbility() : this(0)
        {

        }

        public LanguageAbility(int id) : this(id, default)
        {

        }

        public LanguageAbility(int id, byte[] timeStamp) : base(id, timeStamp, LanguageAbility.Informer)
        {

        }

        #endregion

        #region Properties

		
        public HR.Person Person { get; set; }
		
        public Base.Language Language { get; set; }
		
        public HR.AbilityLevel WritingLevel { get; set; }
		
        public HR.AbilityLevel ReadingLevel { get; set; }
		
        public HR.AbilityLevel SpeackingLevel { get; set; }
		
        public HR.AbilityLevel ListeningLevel { get; set; }
		
		public string Comment { get; set; }

		#endregion

        #region    List Of Related Entities

		#endregion

        
        public override bool Validate()
        {
            return Person.Validate() &&
					Language.Validate() &&
					WritingLevel.Validate() &&
					ReadingLevel.Validate() &&
					SpeackingLevel.Validate() &&
					ListeningLevel.Validate();
        }
    }
}
