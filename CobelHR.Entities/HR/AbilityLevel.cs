using System;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.Entities.Validator;
using CobelHR.Entities.HR;

namespace CobelHR.Entities.HR
{
    public class AbilityLevel : EntityBase, IEntityBase
    {
        public static Info Informer { get; } = new Info("HR", "AbilityLevel", "AbilityLevel");

        #region Constructor
        public AbilityLevel() : this(0)
        {

        }

        public AbilityLevel(int id) : this(id, default)
        {

        }

        public AbilityLevel(int id, byte[] timeStamp) : base(id, timeStamp, AbilityLevel.Informer)
        {

        }

        #endregion

        #region Properties

		
		public string Title { get; set; }
		
		public bool? IsActive { get; set; }

		#endregion

        #region    List Of Related Entities

		[JsonIgnore]
		public List<LanguageAbility> ListOfListeningLevel_LanguageAbility { get; set; }

		[JsonIgnore]
		public List<LanguageAbility> ListOfSpeackingLevel_LanguageAbility { get; set; }

		[JsonIgnore]
		public List<LanguageAbility> ListOfReadingLevel_LanguageAbility { get; set; }

		[JsonIgnore]
		public List<LanguageAbility> ListOfWritingLevel_LanguageAbility { get; set; }

		#endregion

        
        public override bool Validate()
        {
            return Title.Validate() &&
					IsActive.Validate();
        }
    }
}
