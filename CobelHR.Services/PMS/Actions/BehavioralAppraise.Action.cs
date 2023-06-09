
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
    public static class BehavioralAppraise_Action
    {
		
        public static async Task<DataResult<BehavioralAppraise>> SaveAttached(this BehavioralAppraise behavioralAppraise, UserCredit userCredit)
        {
            var permissionType = behavioralAppraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(behavioralAppraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<BehavioralAppraise>(-1, "You don't have Save Permission for ''BehavioralAppraise''", behavioralAppraise);

            return await behavioralAppraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<BehavioralAppraise>> SaveAttached(this BehavioralAppraise behavioralAppraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IBehavioralAppraiseService behavioralAppraiseService = new BehavioralAppraiseService();

            var result = await behavioralAppraiseService.Save(behavioralAppraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<BehavioralAppraise>(behavioralAppraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<BehavioralAppraise>(behavioralAppraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<BehavioralAppraise>> SaveCollection(this List<BehavioralAppraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<BehavioralAppraise> result = new SuccessfulDataResult<BehavioralAppraise>();

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
