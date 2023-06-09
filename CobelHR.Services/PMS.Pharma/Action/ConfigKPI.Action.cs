
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Abstract;


namespace CobelHR.Services.PMS.Pharma.Actions
{
    public static class ConfigKPI_Action
    {
		
        public static async Task<DataResult<ConfigKPI>> SaveAttached(this ConfigKPI configKPI, UserCredit userCredit)
        {
            var permissionType = configKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConfigKPI>(-1, "You don't have Save Permission for ''ConfigKPI''", configKPI);

            return await configKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConfigKPI>> SaveAttached(this ConfigKPI configKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConfigKPIService configKPIService = new ConfigKPIService();

            var result = await configKPIService.Save(configKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConfigKPI>(configKPI);

            

            if (depth > 0)

                return new SuccessfulDataResult<ConfigKPI>(configKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConfigKPI>> SaveCollection(this List<ConfigKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConfigKPI> result = new SuccessfulDataResult<ConfigKPI>();

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
