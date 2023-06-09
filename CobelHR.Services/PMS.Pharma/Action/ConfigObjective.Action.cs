
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
    public static class ConfigObjective_Action
    {
		
        public static async Task<DataResult<ConfigObjective>> SaveAttached(this ConfigObjective configObjective, UserCredit userCredit)
        {
            var permissionType = configObjective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configObjective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConfigObjective>(-1, "You don't have Save Permission for ''ConfigObjective''", configObjective);

            return await configObjective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConfigObjective>> SaveAttached(this ConfigObjective configObjective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConfigObjectiveService configObjectiveService = new ConfigObjectiveService();

            var result = await configObjectiveService.Save(configObjective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConfigObjective>(configObjective);

            Result childResult = null;

            if(configObjective.ListOfConfigKPI.CheckList())
            {
                configObjective.ListOfConfigKPI.ForEach(i => i.ConfigObjective.Id = result.Id);

                childResult = await configObjective.ListOfConfigKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConfigObjective>(configObjective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ConfigObjective>(configObjective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConfigObjective>> SaveCollection(this List<ConfigObjective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConfigObjective> result = new SuccessfulDataResult<ConfigObjective>();

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
