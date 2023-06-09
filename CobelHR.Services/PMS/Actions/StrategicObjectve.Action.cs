
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
    public static class StrategicObjectve_Action
    {
		
        public static async Task<DataResult<StrategicObjectve>> SaveAttached(this StrategicObjectve strategicObjectve, UserCredit userCredit)
        {
            var permissionType = strategicObjectve.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(strategicObjectve.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<StrategicObjectve>(-1, "You don't have Save Permission for ''StrategicObjectve''", strategicObjectve);

            return await strategicObjectve.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<StrategicObjectve>> SaveAttached(this StrategicObjectve strategicObjectve, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IStrategicObjectveService strategicObjectveService = new StrategicObjectveService();

            var result = await strategicObjectveService.Save(strategicObjectve, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<StrategicObjectve>(strategicObjectve);

            

            if (depth > 0)

                return new SuccessfulDataResult<StrategicObjectve>(strategicObjectve);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<StrategicObjectve>> SaveCollection(this List<StrategicObjectve> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<StrategicObjectve> result = new SuccessfulDataResult<StrategicObjectve>();

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
