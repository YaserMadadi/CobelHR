using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IAbilityLevelService : IService<AbilityLevel>
    {
        DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_ListeningLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit);

		DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_SpeackingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit);

		DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_ReadingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit);

		DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_WritingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit);
    }
}
