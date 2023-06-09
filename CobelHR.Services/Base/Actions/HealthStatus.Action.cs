
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class HealthStatus_Action
    {
		
        public static async Task<DataResult<HealthStatus>> SaveAttached(this HealthStatus healthStatus, UserCredit userCredit)
        {
            var permissionType = healthStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(healthStatus.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<HealthStatus>(-1, "You don't have Save Permission for ''HealthStatus''", healthStatus);

            return await healthStatus.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<HealthStatus>> SaveAttached(this HealthStatus healthStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IHealthStatusService healthStatusService = new HealthStatusService();

            var result = await healthStatusService.Save(healthStatus, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<HealthStatus>(healthStatus);

            Result childResult = null;

            if(healthStatus.ListOfPerson.CheckList())
            {
                healthStatus.ListOfPerson.ForEach(i => i.HealthStatus.Id = result.Id);

                childResult = await healthStatus.ListOfPerson.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<HealthStatus>(healthStatus);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<HealthStatus>(healthStatus);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<HealthStatus>> SaveCollection(this List<HealthStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<HealthStatus> result = new SuccessfulDataResult<HealthStatus>();

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
