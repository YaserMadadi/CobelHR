
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
    public static class MilitaryServiceInclusive_Action
    {
		
        public static async Task<DataResult<MilitaryServiceInclusive>> SaveAttached(this MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit)
        {
            var permissionType = militaryServiceInclusive.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(militaryServiceInclusive.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MilitaryServiceInclusive>(-1, "You don't have Save Permission for ''MilitaryServiceInclusive''", militaryServiceInclusive);

            return await militaryServiceInclusive.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MilitaryServiceInclusive>> SaveAttached(this MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMilitaryServiceInclusiveService militaryServiceInclusiveService = new MilitaryServiceInclusiveService();

            var result = await militaryServiceInclusiveService.Save(militaryServiceInclusive, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MilitaryServiceInclusive>(militaryServiceInclusive);

            

            if (depth > 0)

                return new SuccessfulDataResult<MilitaryServiceInclusive>(militaryServiceInclusive);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MilitaryServiceInclusive>> SaveCollection(this List<MilitaryServiceInclusive> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MilitaryServiceInclusive> result = new SuccessfulDataResult<MilitaryServiceInclusive>();

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
