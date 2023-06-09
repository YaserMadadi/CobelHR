
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
    public static class DevelopmentPlanCompetency_Action
    {
		
        public static async Task<DataResult<DevelopmentPlanCompetency>> SaveAttached(this DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit)
        {
            var permissionType = developmentPlanCompetency.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(developmentPlanCompetency.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DevelopmentPlanCompetency>(-1, "You don't have Save Permission for ''DevelopmentPlanCompetency''", developmentPlanCompetency);

            return await developmentPlanCompetency.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DevelopmentPlanCompetency>> SaveAttached(this DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDevelopmentPlanCompetencyService developmentPlanCompetencyService = new DevelopmentPlanCompetencyService();

            var result = await developmentPlanCompetencyService.Save(developmentPlanCompetency, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DevelopmentPlanCompetency>(developmentPlanCompetency);

            

            if (depth > 0)

                return new SuccessfulDataResult<DevelopmentPlanCompetency>(developmentPlanCompetency);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DevelopmentPlanCompetency>> SaveCollection(this List<DevelopmentPlanCompetency> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DevelopmentPlanCompetency> result = new SuccessfulDataResult<DevelopmentPlanCompetency>();

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
