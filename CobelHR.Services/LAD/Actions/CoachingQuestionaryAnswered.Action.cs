
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
    public static class CoachingQuestionaryAnswered_Action
    {
		
        public static async Task<DataResult<CoachingQuestionaryAnswered>> SaveAttached(this CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit)
        {
            var permissionType = coachingQuestionaryAnswered.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coachingQuestionaryAnswered.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CoachingQuestionaryAnswered>(-1, "You don't have Save Permission for ''CoachingQuestionaryAnswered''", coachingQuestionaryAnswered);

            return await coachingQuestionaryAnswered.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CoachingQuestionaryAnswered>> SaveAttached(this CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachingQuestionaryAnsweredService coachingQuestionaryAnsweredService = new CoachingQuestionaryAnsweredService();

            var result = await coachingQuestionaryAnsweredService.Save(coachingQuestionaryAnswered, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CoachingQuestionaryAnswered>(coachingQuestionaryAnswered);

            

            if (depth > 0)

                return new SuccessfulDataResult<CoachingQuestionaryAnswered>(coachingQuestionaryAnswered);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CoachingQuestionaryAnswered>> SaveCollection(this List<CoachingQuestionaryAnswered> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CoachingQuestionaryAnswered> result = new SuccessfulDataResult<CoachingQuestionaryAnswered>();

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
