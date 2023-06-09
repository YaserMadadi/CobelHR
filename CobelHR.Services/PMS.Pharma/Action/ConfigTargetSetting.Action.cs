
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
    public static class ConfigTargetSetting_Action
    {
		
        public static async Task<DataResult<PharmaConfigTargetSetting>> SaveAttached(this PharmaConfigTargetSetting configTargetSetting, UserCredit userCredit)
        {
            var permissionType = configTargetSetting.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(configTargetSetting.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PharmaConfigTargetSetting>(-1, "You don't have Save Permission for ''ConfigTargetSetting''", configTargetSetting);

            return await configTargetSetting.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PharmaConfigTargetSetting>> SaveAttached(this PharmaConfigTargetSetting configTargetSetting, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPharmaConfigTargetSettingService configTargetSettingService = new PharmaConfigTargetSettingService();

            var result = await configTargetSettingService.Save(configTargetSetting, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PharmaConfigTargetSetting>(configTargetSetting);

            Result childResult = null;

            if(configTargetSetting.ListOfConfigObjective.CheckList())
            {
                configTargetSetting.ListOfConfigObjective.ForEach(i => i.ConfigTargetSetting.Id = result.Id);

                childResult = await configTargetSetting.ListOfConfigObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PharmaConfigTargetSetting>(configTargetSetting);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<PharmaConfigTargetSetting>(configTargetSetting);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PharmaConfigTargetSetting>> SaveCollection(this List<PharmaConfigTargetSetting> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PharmaConfigTargetSetting> result = new SuccessfulDataResult<PharmaConfigTargetSetting>();

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
