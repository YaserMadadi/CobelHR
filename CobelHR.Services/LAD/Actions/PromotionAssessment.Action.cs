
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
    public static class PromotionAssessment_Action
    {
		
        public static async Task<DataResult<PromotionAssessment>> SaveAttached(this PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            var permissionType = promotionAssessment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(promotionAssessment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PromotionAssessment>(-1, "You don't have Save Permission for ''PromotionAssessment''", promotionAssessment);

            return await promotionAssessment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PromotionAssessment>> SaveAttached(this PromotionAssessment promotionAssessment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPromotionAssessmentService promotionAssessmentService = new PromotionAssessmentService();

            var result = await promotionAssessmentService.Save(promotionAssessment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PromotionAssessment>(promotionAssessment);

            

            if (depth > 0)

                return new SuccessfulDataResult<PromotionAssessment>(promotionAssessment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PromotionAssessment>> SaveCollection(this List<PromotionAssessment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PromotionAssessment> result = new SuccessfulDataResult<PromotionAssessment>();

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
