
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
    public static class ConfigTargetSetting_Action
    {
		
        public static async Task<DataResult<ConfigTargetSetting>> SaveAttached(this ConfigTargetSetting configTargetSetting, UserCredit userCredit)
        {
            var permissionType = configTargetSetting.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configTargetSetting.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConfigTargetSetting>(-1, "You don't have Save Permission for ''ConfigTargetSetting''", configTargetSetting);

            return await configTargetSetting.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConfigTargetSetting>> SaveAttached(this ConfigTargetSetting configTargetSetting, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConfigTargetSettingService configTargetSettingService = new ConfigTargetSettingService();

            var result = await configTargetSettingService.Save(configTargetSetting, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConfigTargetSetting>(configTargetSetting);

            Result childResult = null;

            if(configTargetSetting.ListOfConfigQualitativeObjective.CheckList())
            {
                configTargetSetting.ListOfConfigQualitativeObjective.ForEach(i => i.ConfigTargetSetting.Id = result.Id);

                childResult = await configTargetSetting.ListOfConfigQualitativeObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConfigTargetSetting>(configTargetSetting);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ConfigTargetSetting>(configTargetSetting);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConfigTargetSetting>> SaveCollection(this List<ConfigTargetSetting> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConfigTargetSetting> result = new SuccessfulDataResult<ConfigTargetSetting>();

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
