
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
    public static class Objective_Action
    {
		
        public static async Task<DataResult<Objective>> SaveAttached(this Objective objective, UserCredit userCredit)
        {
            var permissionType = objective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(objective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Objective>(-1, "You don't have Save Permission for ''Objective''", objective);

            return await objective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Objective>> SaveAttached(this Objective objective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IObjectiveService objectiveService = new ObjectiveService();

            var result = await objectiveService.Save(objective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Objective>(objective);

            Result childResult = null;

            if(objective.ListOfKPI.CheckList())
            {
                objective.ListOfKPI.ForEach(i => i.Objective.Id = result.Id);

                childResult = await objective.ListOfKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Objective>(objective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Objective>(objective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Objective>> SaveCollection(this List<Objective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Objective> result = new SuccessfulDataResult<Objective>();

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
