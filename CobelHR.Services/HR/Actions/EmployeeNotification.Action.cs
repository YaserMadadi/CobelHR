
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
    public static class EmployeeNotification_Action
    {
		
        public static async Task<DataResult<EmployeeNotification>> SaveAttached(this EmployeeNotification employeeNotification, UserCredit userCredit)
        {
            var permissionType = employeeNotification.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employeeNotification.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EmployeeNotification>(-1, "You don't have Save Permission for ''EmployeeNotification''", employeeNotification);

            return await employeeNotification.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EmployeeNotification>> SaveAttached(this EmployeeNotification employeeNotification, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmployeeNotificationService employeeNotificationService = new EmployeeNotificationService();

            var result = await employeeNotificationService.Save(employeeNotification, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EmployeeNotification>(employeeNotification);

            

            if (depth > 0)

                return new SuccessfulDataResult<EmployeeNotification>(employeeNotification);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EmployeeNotification>> SaveCollection(this List<EmployeeNotification> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EmployeeNotification> result = new SuccessfulDataResult<EmployeeNotification>();

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
