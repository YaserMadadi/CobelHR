
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
    public static class PromotionResult_Action
    {
		
        public static async Task<DataResult<PromotionResult>> SaveAttached(this PromotionResult promotionResult, UserCredit userCredit)
        {
            var permissionType = promotionResult.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(promotionResult.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PromotionResult>(-1, "You don't have Save Permission for ''PromotionResult''", promotionResult);

            return await promotionResult.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PromotionResult>> SaveAttached(this PromotionResult promotionResult, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPromotionResultService promotionResultService = new PromotionResultService();

            var result = await promotionResultService.Save(promotionResult, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PromotionResult>(promotionResult);

            Result childResult = null;

            if(promotionResult.ListOfPromotionAssessment.CheckList())
            {
                promotionResult.ListOfPromotionAssessment.ForEach(i => i.PromotionResult.Id = result.Id);

                childResult = await promotionResult.ListOfPromotionAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PromotionResult>(promotionResult);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<PromotionResult>(promotionResult);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PromotionResult>> SaveCollection(this List<PromotionResult> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PromotionResult> result = new SuccessfulDataResult<PromotionResult>();

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
