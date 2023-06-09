
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class CriticalIncident_Action
    {
		
        public static async Task<DataResult<CriticalIncident>> SaveAttached(this CriticalIncident criticalIncident, UserCredit userCredit)
        {
            var permissionType = criticalIncident.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(criticalIncident.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CriticalIncident>(-1, "You don't have Save Permission for ''CriticalIncident''", criticalIncident);

            return await criticalIncident.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CriticalIncident>> SaveAttached(this CriticalIncident criticalIncident, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICriticalIncidentService criticalIncidentService = new CriticalIncidentService();

            var result = await criticalIncidentService.Save(criticalIncident, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CriticalIncident>(criticalIncident);

            Result childResult = null;

            if(criticalIncident.ListOfCriticalIncidentRecognition.CheckList())
            {
                criticalIncident.ListOfCriticalIncidentRecognition.ForEach(i => i.CriticalIncident.Id = result.Id);

                childResult = await criticalIncident.ListOfCriticalIncidentRecognition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CriticalIncident>(criticalIncident);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CriticalIncident>(criticalIncident);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CriticalIncident>> SaveCollection(this List<CriticalIncident> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CriticalIncident> result = new SuccessfulDataResult<CriticalIncident>();

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
