
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class LanguageAbility_Action
    {
		
        public static async Task<DataResult<LanguageAbility>> SaveAttached(this LanguageAbility languageAbility, UserCredit userCredit)
        {
            var permissionType = languageAbility.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(languageAbility.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<LanguageAbility>(-1, "You don't have Save Permission for ''LanguageAbility''", languageAbility);

            return await languageAbility.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<LanguageAbility>> SaveAttached(this LanguageAbility languageAbility, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ILanguageAbilityService languageAbilityService = new LanguageAbilityService();

            var result = await languageAbilityService.Save(languageAbility, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<LanguageAbility>(languageAbility);

            

            if (depth > 0)

                return new SuccessfulDataResult<LanguageAbility>(languageAbility);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<LanguageAbility>> SaveCollection(this List<LanguageAbility> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<LanguageAbility> result = new SuccessfulDataResult<LanguageAbility>();

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
