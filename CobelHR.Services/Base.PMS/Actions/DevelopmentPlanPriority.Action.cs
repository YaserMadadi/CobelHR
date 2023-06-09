
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
    public static class DevelopmentPlanPriority_Action
    {
		
        public static async Task<DataResult<DevelopmentPlanPriority>> SaveAttached(this DevelopmentPlanPriority developmentPlanPriority, UserCredit userCredit)
        {
            var permissionType = developmentPlanPriority.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(developmentPlanPriority.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DevelopmentPlanPriority>(-1, "You don't have Save Permission for ''DevelopmentPlanPriority''", developmentPlanPriority);

            return await developmentPlanPriority.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DevelopmentPlanPriority>> SaveAttached(this DevelopmentPlanPriority developmentPlanPriority, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDevelopmentPlanPriorityService developmentPlanPriorityService = new DevelopmentPlanPriorityService();

            var result = await developmentPlanPriorityService.Save(developmentPlanPriority, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DevelopmentPlanPriority>(developmentPlanPriority);

            Result childResult = null;

            if(developmentPlanPriority.ListOfPriority_IndividualDevelopmentPlan.CheckList())
            {
                developmentPlanPriority.ListOfPriority_IndividualDevelopmentPlan.ForEach(i => i.Priority.Id = result.Id);

                childResult = await developmentPlanPriority.ListOfPriority_IndividualDevelopmentPlan.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<DevelopmentPlanPriority>(developmentPlanPriority);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<DevelopmentPlanPriority>(developmentPlanPriority);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DevelopmentPlanPriority>> SaveCollection(this List<DevelopmentPlanPriority> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DevelopmentPlanPriority> result = new SuccessfulDataResult<DevelopmentPlanPriority>();

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
