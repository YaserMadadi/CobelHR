using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface ILanguageService : IService<Language>
    {
        DataResult<List<LanguageAbility>> CollectionOfLanguageAbility(int language_Id, LanguageAbility languageAbility, UserCredit userCredit);
    }
}
