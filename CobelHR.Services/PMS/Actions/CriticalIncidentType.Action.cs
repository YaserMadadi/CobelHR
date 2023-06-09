
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
    public static class CriticalIncidentType_Action
    {
		
        public static async Task<DataResult<CriticalIncidentType>> SaveAttached(this CriticalIncidentType criticalIncidentType, UserCredit userCredit)
        {
            var permissionType = criticalIncidentType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(criticalIncidentType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CriticalIncidentType>(-1, "You don't have Save Permission for ''CriticalIncidentType''", criticalIncidentType);

            return await criticalIncidentType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CriticalIncidentType>> SaveAttached(this CriticalIncidentType criticalIncidentType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICriticalIncidentTypeService criticalIncidentTypeService = new CriticalIncidentTypeService();

            var result = await criticalIncidentTypeService.Save(criticalIncidentType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CriticalIncidentType>(criticalIncidentType);

            Result childResult = null;

            if(criticalIncidentType.ListOfCriticalIncident.CheckList())
            {
                criticalIncidentType.ListOfCriticalIncident.ForEach(i => i.CriticalIncidentType.Id = result.Id);

                childResult = await criticalIncidentType.ListOfCriticalIncident.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CriticalIncidentType>(criticalIncidentType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CriticalIncidentType>(criticalIncidentType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CriticalIncidentType>> SaveCollection(this List<CriticalIncidentType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CriticalIncidentType> result = new SuccessfulDataResult<CriticalIncidentType>();

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
