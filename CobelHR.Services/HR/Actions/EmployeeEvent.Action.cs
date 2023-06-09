
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
    public static class EmployeeEvent_Action
    {
		
        public static async Task<DataResult<EmployeeEvent>> SaveAttached(this EmployeeEvent employeeEvent, UserCredit userCredit)
        {
            var permissionType = employeeEvent.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employeeEvent.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EmployeeEvent>(-1, "You don't have Save Permission for ''EmployeeEvent''", employeeEvent);

            return await employeeEvent.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EmployeeEvent>> SaveAttached(this EmployeeEvent employeeEvent, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmployeeEventService employeeEventService = new EmployeeEventService();

            var result = await employeeEventService.Save(employeeEvent, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EmployeeEvent>(employeeEvent);

            

            if (depth > 0)

                return new SuccessfulDataResult<EmployeeEvent>(employeeEvent);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EmployeeEvent>> SaveCollection(this List<EmployeeEvent> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EmployeeEvent> result = new SuccessfulDataResult<EmployeeEvent>();

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
