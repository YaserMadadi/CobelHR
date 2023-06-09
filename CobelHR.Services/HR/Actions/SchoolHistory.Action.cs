
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
    public static class SchoolHistory_Action
    {
		
        public static async Task<DataResult<SchoolHistory>> SaveAttached(this SchoolHistory schoolHistory, UserCredit userCredit)
        {
            var permissionType = schoolHistory.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(schoolHistory.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<SchoolHistory>(-1, "You don't have Save Permission for ''SchoolHistory''", schoolHistory);

            return await schoolHistory.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<SchoolHistory>> SaveAttached(this SchoolHistory schoolHistory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ISchoolHistoryService schoolHistoryService = new SchoolHistoryService();

            var result = await schoolHistoryService.Save(schoolHistory, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<SchoolHistory>(schoolHistory);

            

            if (depth > 0)

                return new SuccessfulDataResult<SchoolHistory>(schoolHistory);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<SchoolHistory>> SaveCollection(this List<SchoolHistory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<SchoolHistory> result = new SuccessfulDataResult<SchoolHistory>();

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
