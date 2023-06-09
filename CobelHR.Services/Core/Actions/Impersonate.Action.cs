
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Abstract;


namespace CobelHR.Services.Core.Actions
{
    public static class Impersonate_Action
    {
		
        public static async Task<DataResult<Impersonate>> SaveAttached(this Impersonate impersonate, UserCredit userCredit)
        {
            var permissionType = impersonate.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(impersonate.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Impersonate>(-1, "You don't have Save Permission for ''Impersonate''", impersonate);

            return await impersonate.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Impersonate>> SaveAttached(this Impersonate impersonate, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IImpersonateService impersonateService = new ImpersonateService();

            var result = await impersonateService.Save(impersonate, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Impersonate>(impersonate);

            

            if (depth > 0)

                return new SuccessfulDataResult<Impersonate>(impersonate);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Impersonate>> SaveCollection(this List<Impersonate> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Impersonate> result = new SuccessfulDataResult<Impersonate>();

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
