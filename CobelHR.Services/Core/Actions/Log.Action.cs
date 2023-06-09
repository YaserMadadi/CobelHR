
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
    public static class Log_Action
    {
		
        public static async Task<DataResult<Log>> SaveAttached(this Log log, UserCredit userCredit)
        {
            var permissionType = log.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(log.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Log>(-1, "You don't have Save Permission for ''Log''", log);

            return await log.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Log>> SaveAttached(this Log log, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ILogService logService = new LogService();

            var result = await logService.Save(log, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Log>(log);

            

            if (depth > 0)

                return new SuccessfulDataResult<Log>(log);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Log>> SaveCollection(this List<Log> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Log> result = new SuccessfulDataResult<Log>();

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
