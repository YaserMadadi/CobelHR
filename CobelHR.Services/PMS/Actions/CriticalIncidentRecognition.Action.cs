
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
    public static class CriticalIncidentRecognition_Action
    {
		
        public static async Task<DataResult<CriticalIncidentRecognition>> SaveAttached(this CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit)
        {
            var permissionType = criticalIncidentRecognition.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(criticalIncidentRecognition.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CriticalIncidentRecognition>(-1, "You don't have Save Permission for ''CriticalIncidentRecognition''", criticalIncidentRecognition);

            return await criticalIncidentRecognition.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CriticalIncidentRecognition>> SaveAttached(this CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICriticalIncidentRecognitionService criticalIncidentRecognitionService = new CriticalIncidentRecognitionService();

            var result = await criticalIncidentRecognitionService.Save(criticalIncidentRecognition, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CriticalIncidentRecognition>(criticalIncidentRecognition);

            

            if (depth > 0)

                return new SuccessfulDataResult<CriticalIncidentRecognition>(criticalIncidentRecognition);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CriticalIncidentRecognition>> SaveCollection(this List<CriticalIncidentRecognition> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CriticalIncidentRecognition> result = new SuccessfulDataResult<CriticalIncidentRecognition>();

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
