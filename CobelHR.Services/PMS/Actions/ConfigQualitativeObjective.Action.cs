
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
    public static class ConfigQualitativeObjective_Action
    {
		
        public static async Task<DataResult<ConfigQualitativeObjective>> SaveAttached(this ConfigQualitativeObjective configQualitativeObjective, UserCredit userCredit)
        {
            var permissionType = configQualitativeObjective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configQualitativeObjective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConfigQualitativeObjective>(-1, "You don't have Save Permission for ''ConfigQualitativeObjective''", configQualitativeObjective);

            return await configQualitativeObjective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConfigQualitativeObjective>> SaveAttached(this ConfigQualitativeObjective configQualitativeObjective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConfigQualitativeObjectiveService configQualitativeObjectiveService = new ConfigQualitativeObjectiveService();

            var result = await configQualitativeObjectiveService.Save(configQualitativeObjective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConfigQualitativeObjective>(configQualitativeObjective);

            Result childResult = null;

            if(configQualitativeObjective.ListOfConfigQualitativeKPI.CheckList())
            {
                configQualitativeObjective.ListOfConfigQualitativeKPI.ForEach(i => i.ConfigQualitativeObjective.Id = result.Id);

                childResult = await configQualitativeObjective.ListOfConfigQualitativeKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConfigQualitativeObjective>(configQualitativeObjective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ConfigQualitativeObjective>(configQualitativeObjective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConfigQualitativeObjective>> SaveCollection(this List<ConfigQualitativeObjective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConfigQualitativeObjective> result = new SuccessfulDataResult<ConfigQualitativeObjective>();

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
