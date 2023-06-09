
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class TargetSettingType_Action
    {
		
        public static async Task<DataResult<TargetSettingType>> SaveAttached(this TargetSettingType targetSettingType, UserCredit userCredit)
        {
            var permissionType = targetSettingType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(targetSettingType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<TargetSettingType>(-1, "You don't have Save Permission for ''TargetSettingType''", targetSettingType);

            return await targetSettingType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<TargetSettingType>> SaveAttached(this TargetSettingType targetSettingType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ITargetSettingTypeService targetSettingTypeService = new TargetSettingTypeService();

            var result = await targetSettingTypeService.Save(targetSettingType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<TargetSettingType>(targetSettingType);

            Result childResult = null;

            if(targetSettingType.ListOfTargetSetting.CheckList())
            {
                targetSettingType.ListOfTargetSetting.ForEach(i => i.TargetSettingType.Id = result.Id);

                childResult = await targetSettingType.ListOfTargetSetting.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSettingType>(targetSettingType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<TargetSettingType>(targetSettingType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<TargetSettingType>> SaveCollection(this List<TargetSettingType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<TargetSettingType> result = new SuccessfulDataResult<TargetSettingType>();

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
