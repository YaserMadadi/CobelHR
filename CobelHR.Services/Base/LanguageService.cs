using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class LanguageService : Service<Language>, ILanguageService
    {
        public LanguageService() : base()
        {
        }

        public override async Task<DataResult<Language>> SaveAttached(Language language, UserCredit userCredit)
        {
            return await language.SaveAttached(userCredit);
        }

        public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility(int language_Id, LanguageAbility languageAbility, UserCredit userCredit)
        {
            var procedureName = "[Base].[Language.CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",language_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }
    }
}