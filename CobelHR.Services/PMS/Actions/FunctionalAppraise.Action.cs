
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
    public static class FunctionalAppraise_Action
    {
		
        public static async Task<DataResult<FunctionalAppraise>> SaveAttached(this FunctionalAppraise functionalAppraise, UserCredit userCredit)
        {
            var permissionType = functionalAppraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(functionalAppraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FunctionalAppraise>(-1, "You don't have Save Permission for ''FunctionalAppraise''", functionalAppraise);

            return await functionalAppraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FunctionalAppraise>> SaveAttached(this FunctionalAppraise functionalAppraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFunctionalAppraiseService functionalAppraiseService = new FunctionalAppraiseService();

            var result = await functionalAppraiseService.Save(functionalAppraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FunctionalAppraise>(functionalAppraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<FunctionalAppraise>(functionalAppraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FunctionalAppraise>> SaveCollection(this List<FunctionalAppraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FunctionalAppraise> result = new SuccessfulDataResult<FunctionalAppraise>();

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
