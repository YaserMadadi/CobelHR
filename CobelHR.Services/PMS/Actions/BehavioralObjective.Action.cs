
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
    public static class BehavioralObjective_Action
    {
		
        public static async Task<DataResult<BehavioralObjective>> SaveAttached(this BehavioralObjective behavioralObjective, UserCredit userCredit)
        {
            var permissionType = behavioralObjective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(behavioralObjective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<BehavioralObjective>(-1, "You don't have Save Permission for ''BehavioralObjective''", behavioralObjective);

            return await behavioralObjective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<BehavioralObjective>> SaveAttached(this BehavioralObjective behavioralObjective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IBehavioralObjectiveService behavioralObjectiveService = new BehavioralObjectiveService();

            var result = await behavioralObjectiveService.Save(behavioralObjective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<BehavioralObjective>(behavioralObjective);

            Result childResult = null;

            if(behavioralObjective.ListOfBehavioralKPI.CheckList())
            {
                behavioralObjective.ListOfBehavioralKPI.ForEach(i => i.BehavioralObjective.Id = result.Id);

                childResult = await behavioralObjective.ListOfBehavioralKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<BehavioralObjective>(behavioralObjective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<BehavioralObjective>(behavioralObjective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<BehavioralObjective>> SaveCollection(this List<BehavioralObjective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<BehavioralObjective> result = new SuccessfulDataResult<BehavioralObjective>();

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
