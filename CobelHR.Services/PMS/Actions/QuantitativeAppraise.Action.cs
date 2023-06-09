
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
    public static class QuantitativeAppraise_Action
    {
		
        public static async Task<DataResult<QuantitativeAppraise>> SaveAttached(this QuantitativeAppraise quantitativeAppraise, UserCredit userCredit)
        {
            var permissionType = quantitativeAppraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(quantitativeAppraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QuantitativeAppraise>(-1, "You don't have Save Permission for ''QuantitativeAppraise''", quantitativeAppraise);

            return await quantitativeAppraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QuantitativeAppraise>> SaveAttached(this QuantitativeAppraise quantitativeAppraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQuantitativeAppraiseService quantitativeAppraiseService = new QuantitativeAppraiseService();

            var result = await quantitativeAppraiseService.Save(quantitativeAppraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QuantitativeAppraise>(quantitativeAppraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<QuantitativeAppraise>(quantitativeAppraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QuantitativeAppraise>> SaveCollection(this List<QuantitativeAppraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QuantitativeAppraise> result = new SuccessfulDataResult<QuantitativeAppraise>();

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
