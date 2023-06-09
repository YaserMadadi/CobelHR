
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class Language_Action
    {
		
        public static async Task<DataResult<Language>> SaveAttached(this Language language, UserCredit userCredit)
        {
            var permissionType = language.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(language.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Language>(-1, "You don't have Save Permission for ''Language''", language);

            return await language.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Language>> SaveAttached(this Language language, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ILanguageService languageService = new LanguageService();

            var result = await languageService.Save(language, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Language>(language);

            Result childResult = null;

            if(language.ListOfLanguageAbility.CheckList())
            {
                language.ListOfLanguageAbility.ForEach(i => i.Language.Id = result.Id);

                childResult = await language.ListOfLanguageAbility.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Language>(language);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Language>(language);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Language>> SaveCollection(this List<Language> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Language> result = new SuccessfulDataResult<Language>();

            foreach (var item in list)
            {
                result = await item.SaveAttached(userCredit, transaction, depth + 1);

                if (result.Id <= 0)

                    break;
            }

            return result;
        }
    }
}
