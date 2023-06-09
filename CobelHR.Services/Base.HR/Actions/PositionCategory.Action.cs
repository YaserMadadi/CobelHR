
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class PositionCategory_Action
    {
		
        public static async Task<DataResult<PositionCategory>> SaveAttached(this PositionCategory positionCategory, UserCredit userCredit)
        {
            var permissionType = positionCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(positionCategory.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PositionCategory>(-1, "You don't have Save Permission for ''PositionCategory''", positionCategory);

            return await positionCategory.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PositionCategory>> SaveAttached(this PositionCategory positionCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPositionCategoryService positionCategoryService = new PositionCategoryService();

            var result = await positionCategoryService.Save(positionCategory, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PositionCategory>(positionCategory);

            Result childResult = null;

            if (positionCategory.ListOfConfigTargetSetting.CheckList())
            {
                positionCategory.ListOfConfigTargetSetting.ForEach(i => i.PositionCategory.Id = result.Id);

                childResult = await positionCategory.ListOfConfigTargetSetting.SaveCollection(userCredit, transaction, depth + 1);

                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionCategory>(positionCategory);
                }
            }

            if (positionCategory.ListOfDepartmentCategory_AppraisalApproverConfig.CheckList())
            {
                positionCategory.ListOfDepartmentCategory_AppraisalApproverConfig.ForEach(i => i.DepartmentCategory.Id = result.Id);

                childResult = await positionCategory.ListOfDepartmentCategory_AppraisalApproverConfig.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionCategory>(positionCategory);
                }
            }

            if(positionCategory.ListOfPosition.CheckList())
            {
                positionCategory.ListOfPosition.ForEach(i => i.PositionCategory.Id = result.Id);

                childResult = await positionCategory.ListOfPosition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionCategory>(positionCategory);
                }
            }

            if(positionCategory.ListOfUnit.CheckList())
            {
                positionCategory.ListOfUnit.ForEach(i => i.PositionDivision.Id = result.Id);

                childResult = await positionCategory.ListOfUnit.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionCategory>(positionCategory);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<PositionCategory>(positionCategory);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PositionCategory>> SaveCollection(this List<PositionCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PositionCategory> result = new SuccessfulDataResult<PositionCategory>();

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
