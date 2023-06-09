
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
    public static class ExceptionLog_Action
    {
		
        public static async Task<DataResult<ExceptionLog>> SaveAttached(this ExceptionLog exceptionLog, UserCredit userCredit)
        {
            var permissionType = exceptionLog.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(exceptionLog.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ExceptionLog>(-1, "You don't have Save Permission for ''ExceptionLog''", exceptionLog);

            return await exceptionLog.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ExceptionLog>> SaveAttached(this ExceptionLog exceptionLog, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IExceptionLogService ExceptionLogService = new ExceptionLogService();

            var result = await ExceptionLogService.Save(exceptionLog, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ExceptionLog>(exceptionLog);

            Result childResult = null;

            if(exceptionLog.ListOfCommandParameter.CheckList())
            {
                exceptionLog.ListOfCommandParameter.ForEach(i => i.ExceptionLog.Id = result.Id);

                childResult = await exceptionLog.ListOfCommandParameter.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ExceptionLog>(exceptionLog);
                }
            }

            if (depth > 0)

                return new SuccessfulDataResult<ExceptionLog>(exceptionLog);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ExceptionLog>> SaveCollection(this List<ExceptionLog> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ExceptionLog> result = new SuccessfulDataResult<ExceptionLog>();

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
