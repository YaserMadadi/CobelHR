
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class EmploymentStatus_Action
    {
		
        public static async Task<DataResult<EmploymentStatus>> SaveAttached(this EmploymentStatus employmentStatus, UserCredit userCredit)
        {
            var permissionType = employmentStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(employmentStatus.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EmploymentStatus>(-1, "You don't have Save Permission for ''EmploymentStatus''", employmentStatus);

            return await employmentStatus.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EmploymentStatus>> SaveAttached(this EmploymentStatus employmentStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEmploymentStatusService employmentStatusService = new EmploymentStatusService();

            var result = await employmentStatusService.Save(employmentStatus, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EmploymentStatus>(employmentStatus);

            Result childResult = null;

            if(employmentStatus.ListOfEmployee.CheckList())
            {
                employmentStatus.ListOfEmployee.ForEach(i => i.EmploymentStatus.Id = result.Id);

                childResult = await employmentStatus.ListOfEmployee.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<EmploymentStatus>(employmentStatus);
                }
            }

            if(employmentStatus.ListOfEmployeeDetail.CheckList())
            {
                employmentStatus.ListOfEmployeeDetail.ForEach(i => i.EmploymentStatus.Id = result.Id);

                childResult = await employmentStatus.ListOfEmployeeDetail.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<EmploymentStatus>(employmentStatus);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<EmploymentStatus>(employmentStatus);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EmploymentStatus>> SaveCollection(this List<EmploymentStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EmploymentStatus> result = new SuccessfulDataResult<EmploymentStatus>();

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
