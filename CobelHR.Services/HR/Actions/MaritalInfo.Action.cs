
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
    public static class MaritalInfo_Action
    {
		
        public static async Task<DataResult<MaritalInfo>> SaveAttached(this MaritalInfo maritalInfo, UserCredit userCredit)
        {
            var permissionType = maritalInfo.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(maritalInfo.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MaritalInfo>(-1, "You don't have Save Permission for ''MaritalInfo''", maritalInfo);

            return await maritalInfo.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MaritalInfo>> SaveAttached(this MaritalInfo maritalInfo, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMaritalInfoService maritalInfoService = new MaritalInfoService();

            var result = await maritalInfoService.Save(maritalInfo, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MaritalInfo>(maritalInfo);

            

            if (depth > 0)

                return new SuccessfulDataResult<MaritalInfo>(maritalInfo);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MaritalInfo>> SaveCollection(this List<MaritalInfo> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MaritalInfo> result = new SuccessfulDataResult<MaritalInfo>();

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
