
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
    public static class EmployeeDetail_Action
    {
		
        public static async Task<DataResult<EmployeeDetail>> SaveAttached(this EmployeeDetail employeeDetail, UserCredit userCredit)
        {
            var permissionType = employeeDetail.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employeeDetail.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EmployeeDetail>(-1, "You don't have Save Permission for ''EmployeeDetail''", employeeDetail);

            return await employeeDetail.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EmployeeDetail>> SaveAttached(this EmployeeDetail employeeDetail, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmployeeDetailService employeeDetailService = new EmployeeDetailService();

            var result = await employeeDetailService.Save(employeeDetail, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EmployeeDetail>(employeeDetail);

            

            if (depth > 0)

                return new SuccessfulDataResult<EmployeeDetail>(employeeDetail);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EmployeeDetail>> SaveCollection(this List<EmployeeDetail> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EmployeeDetail> result = new SuccessfulDataResult<EmployeeDetail>();

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
