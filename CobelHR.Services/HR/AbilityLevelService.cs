using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class AbilityLevelService : Service<AbilityLevel>, IAbilityLevelService
    {
        public AbilityLevelService() : base()
        {
        }

        public override async Task<DataResult<AbilityLevel>> SaveAttached(AbilityLevel abilityLevel, UserCredit userCredit)
        {
            return await abilityLevel.SaveAttached(userCredit);
        }

        public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_ListeningLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit)
        {
            var procedureName = "[HR].[AbilityLevel(ListeningLevel).CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",abilityLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }

		public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_SpeackingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit)
        {
            var procedureName = "[HR].[AbilityLevel(SpeackingLevel).CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",abilityLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }

		public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_ReadingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit)
        {
            var procedureName = "[HR].[AbilityLevel(ReadingLevel).CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",abilityLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }

		public DataResult<List<LanguageAbility>> CollectionOfLanguageAbility_WritingLevel(int abilityLevel_Id, LanguageAbility languageAbility, UserCredit userCredit)
        {
            var procedureName = "[HR].[AbilityLevel(WritingLevel).CollectionOfLanguageAbility]";

            return this.CollectionOf<LanguageAbility>(procedureName,
                                                    new SqlParameter("@Id",abilityLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", languageAbility.ToJson()));
        }
    }
}