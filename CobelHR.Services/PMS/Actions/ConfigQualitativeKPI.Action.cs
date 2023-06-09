
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
    public static class ConfigQualitativeKPI_Action
    {
		
        public static async Task<DataResult<ConfigQualitativeKPI>> SaveAttached(this ConfigQualitativeKPI configQualitativeKPI, UserCredit userCredit)
        {
            var permissionType = configQualitativeKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configQualitativeKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConfigQualitativeKPI>(-1, "You don't have Save Permission for ''ConfigQualitativeKPI''", configQualitativeKPI);

            return await configQualitativeKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConfigQualitativeKPI>> SaveAttached(this ConfigQualitativeKPI configQualitativeKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConfigQualitativeKPIService configQualitativeKPIService = new ConfigQualitativeKPIService();

            var result = await configQualitativeKPIService.Save(configQualitativeKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConfigQualitativeKPI>(configQualitativeKPI);

            

            if (depth > 0)

                return new SuccessfulDataResult<ConfigQualitativeKPI>(configQualitativeKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConfigQualitativeKPI>> SaveCollection(this List<ConfigQualitativeKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConfigQualitativeKPI> result = new SuccessfulDataResult<ConfigQualitativeKPI>();

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
