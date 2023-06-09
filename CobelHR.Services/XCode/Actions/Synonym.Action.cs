
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.XCode;
using CobelHR.Services.XCode.Abstract;


namespace CobelHR.Services.XCode.Actions
{
    public static class Synonym_Action
    {
		
        public static async Task<DataResult<Synonym>> SaveAttached(this Synonym synonym, UserCredit userCredit)
        {
            var permissionType = synonym.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(synonym.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Synonym>(-1, "You don't have Save Permission for ''Synonym''", synonym);

            return await synonym.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Synonym>> SaveAttached(this Synonym synonym, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ISynonymService synonymService = new SynonymService();

            var result = await synonymService.Save(synonym, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Synonym>(synonym);

            

            if (depth > 0)

                return new SuccessfulDataResult<Synonym>(synonym);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Synonym>> SaveCollection(this List<Synonym> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Synonym> result = new SuccessfulDataResult<Synonym>();

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
