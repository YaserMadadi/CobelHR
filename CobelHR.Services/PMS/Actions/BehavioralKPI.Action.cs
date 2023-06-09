
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
    public static class BehavioralKPI_Action
    {
		
        public static async Task<DataResult<BehavioralKPI>> SaveAttached(this BehavioralKPI behavioralKPI, UserCredit userCredit)
        {
            var permissionType = behavioralKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(behavioralKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<BehavioralKPI>(-1, "You don't have Save Permission for ''BehavioralKPI''", behavioralKPI);

            return await behavioralKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<BehavioralKPI>> SaveAttached(this BehavioralKPI behavioralKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IBehavioralKPIService behavioralKPIService = new BehavioralKPIService();

            var result = await behavioralKPIService.Save(behavioralKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<BehavioralKPI>(behavioralKPI);

            Result childResult = null;

            if(behavioralKPI.ListOfBehavioralAppraise.CheckList())
            {
                behavioralKPI.ListOfBehavioralAppraise.ForEach(i => i.BehavioralKPI.Id = result.Id);

                childResult = await behavioralKPI.ListOfBehavioralAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<BehavioralKPI>(behavioralKPI);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<BehavioralKPI>(behavioralKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<BehavioralKPI>> SaveCollection(this List<BehavioralKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<BehavioralKPI> result = new SuccessfulDataResult<BehavioralKPI>();

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
