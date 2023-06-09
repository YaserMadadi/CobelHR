
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
    public static class CoachingQuestionaryDetail_Action
    {
		
        public static async Task<DataResult<CoachingQuestionaryDetail>> SaveAttached(this CoachingQuestionaryDetail coachingQuestionaryDetail, UserCredit userCredit)
        {
            var permissionType = coachingQuestionaryDetail.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coachingQuestionaryDetail.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CoachingQuestionaryDetail>(-1, "You don't have Save Permission for ''CoachingQuestionaryDetail''", coachingQuestionaryDetail);

            return await coachingQuestionaryDetail.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CoachingQuestionaryDetail>> SaveAttached(this CoachingQuestionaryDetail coachingQuestionaryDetail, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachingQuestionaryDetailService coachingQuestionaryDetailService = new CoachingQuestionaryDetailService();

            var result = await coachingQuestionaryDetailService.Save(coachingQuestionaryDetail, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CoachingQuestionaryDetail>(coachingQuestionaryDetail);

            

            if (depth > 0)

                return new SuccessfulDataResult<CoachingQuestionaryDetail>(coachingQuestionaryDetail);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CoachingQuestionaryDetail>> SaveCollection(this List<CoachingQuestionaryDetail> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CoachingQuestionaryDetail> result = new SuccessfulDataResult<CoachingQuestionaryDetail>();

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
