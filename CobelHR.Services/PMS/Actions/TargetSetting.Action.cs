
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
    public static class TargetSetting_Action
    {
		
        public static async Task<DataResult<TargetSetting>> SaveAttached(this TargetSetting targetSetting, UserCredit userCredit)
        {
            var permissionType = targetSetting.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(targetSetting.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<TargetSetting>(-1, "You don't have Save Permission for ''TargetSetting''", targetSetting);

            return await targetSetting.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<TargetSetting>> SaveAttached(this TargetSetting targetSetting, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ITargetSettingService targetSettingService = new TargetSettingService();

            var result = await targetSettingService.Save(targetSetting, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<TargetSetting>(targetSetting);

            Result childResult = null;

            if(targetSetting.ListOfAppraiseResult.CheckList())
            {
                targetSetting.ListOfAppraiseResult.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfAppraiseResult.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }

            if(targetSetting.ListOfBehavioralObjective.CheckList())
            {
                targetSetting.ListOfBehavioralObjective.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfBehavioralObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }

            if(targetSetting.ListOfFinalAppraise.CheckList())
            {
                targetSetting.ListOfFinalAppraise.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfFinalAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }

            if(targetSetting.ListOfFunctionalObjective.CheckList())
            {
                targetSetting.ListOfFunctionalObjective.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfFunctionalObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }

            if(targetSetting.ListOfQualitativeObjective.CheckList())
            {
                targetSetting.ListOfQualitativeObjective.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfQualitativeObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }

            if(targetSetting.ListOfQuantitativeAppraise.CheckList())
            {
                targetSetting.ListOfQuantitativeAppraise.ForEach(i => i.TargetSetting.Id = result.Id);

                childResult = await targetSetting.ListOfQuantitativeAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<TargetSetting>(targetSetting);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<TargetSetting>(targetSetting);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<TargetSetting>> SaveCollection(this List<TargetSetting> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<TargetSetting> result = new SuccessfulDataResult<TargetSetting>();

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
