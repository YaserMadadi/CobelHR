
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


namespace CobelHR.Services.Base.HR.Actions
{
    public static class DevelopmentPlanType_Action
    {
		
        public static async Task<DataResult<DevelopmentPlanType>> SaveAttached(this DevelopmentPlanType developmentPlanType, UserCredit userCredit)
        {
            var permissionType = developmentPlanType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(developmentPlanType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DevelopmentPlanType>(-1, "You don't have Save Permission for ''DevelopmentPlanType''", developmentPlanType);

            return await developmentPlanType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DevelopmentPlanType>> SaveAttached(this DevelopmentPlanType developmentPlanType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDevelopmentPlanTypeService developmentPlanTypeService = new DevelopmentPlanTypeService();

            var result = await developmentPlanTypeService.Save(developmentPlanType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DevelopmentPlanType>(developmentPlanType);

            

            if (depth > 0)

                return new SuccessfulDataResult<DevelopmentPlanType>(developmentPlanType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DevelopmentPlanType>> SaveCollection(this List<DevelopmentPlanType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DevelopmentPlanType> result = new SuccessfulDataResult<DevelopmentPlanType>();

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
