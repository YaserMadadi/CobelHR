
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
    public static class FinalAppraise_Action
    {
		
        public static async Task<DataResult<FinalAppraise>> SaveAttached(this FinalAppraise finalAppraise, UserCredit userCredit)
        {
            var permissionType = finalAppraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(finalAppraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FinalAppraise>(-1, "You don't have Save Permission for ''FinalAppraise''", finalAppraise);

            return await finalAppraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FinalAppraise>> SaveAttached(this FinalAppraise finalAppraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFinalAppraiseService finalAppraiseService = new FinalAppraiseService();

            var result = await finalAppraiseService.Save(finalAppraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FinalAppraise>(finalAppraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<FinalAppraise>(finalAppraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FinalAppraise>> SaveCollection(this List<FinalAppraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FinalAppraise> result = new SuccessfulDataResult<FinalAppraise>();

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
