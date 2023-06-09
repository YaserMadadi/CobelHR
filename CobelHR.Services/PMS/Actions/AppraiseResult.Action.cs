
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class AppraiseResult_Action
    {
		
        public static async Task<DataResult<AppraiseResult>> SaveAttached(this AppraiseResult appraiseResult, UserCredit userCredit)
        {
            var permissionType = appraiseResult.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraiseResult.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AppraiseResult>(-1, "You don't have Save Permission for ''AppraiseResult''", appraiseResult);

            return await appraiseResult.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AppraiseResult>> SaveAttached(this AppraiseResult appraiseResult, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraiseResultService appraiseResultService = new AppraiseResultService();

            var result = await appraiseResultService.Save(appraiseResult, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AppraiseResult>(appraiseResult);

            

            if (depth > 0)

                return new SuccessfulDataResult<AppraiseResult>(appraiseResult);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AppraiseResult>> SaveCollection(this List<AppraiseResult> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AppraiseResult> result = new SuccessfulDataResult<AppraiseResult>();

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
