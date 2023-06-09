
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Abstract;


namespace CobelHR.Services.LAD.Actions
{
    public static class DevelopmentGoal_Action
    {
		
        public static async Task<DataResult<DevelopmentGoal>> SaveAttached(this DevelopmentGoal developmentGoal, UserCredit userCredit)
        {
            var permissionType = developmentGoal.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(developmentGoal.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DevelopmentGoal>(-1, "You don't have Save Permission for ''DevelopmentGoal''", developmentGoal);

            return await developmentGoal.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DevelopmentGoal>> SaveAttached(this DevelopmentGoal developmentGoal, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDevelopmentGoalService developmentGoalService = new DevelopmentGoalService();

            var result = await developmentGoalService.Save(developmentGoal, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DevelopmentGoal>(developmentGoal);

            

            if (depth > 0)

                return new SuccessfulDataResult<DevelopmentGoal>(developmentGoal);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DevelopmentGoal>> SaveCollection(this List<DevelopmentGoal> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DevelopmentGoal> result = new SuccessfulDataResult<DevelopmentGoal>();

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
