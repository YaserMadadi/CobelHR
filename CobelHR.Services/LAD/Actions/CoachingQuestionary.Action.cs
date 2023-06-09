
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
    public static class CoachingQuestionary_Action
    {
		
        public static async Task<DataResult<CoachingQuestionary>> SaveAttached(this CoachingQuestionary coachingQuestionary, UserCredit userCredit)
        {
            var permissionType = coachingQuestionary.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coachingQuestionary.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CoachingQuestionary>(-1, "You don't have Save Permission for ''CoachingQuestionary''", coachingQuestionary);

            return await coachingQuestionary.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CoachingQuestionary>> SaveAttached(this CoachingQuestionary coachingQuestionary, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachingQuestionaryService coachingQuestionaryService = new CoachingQuestionaryService();

            var result = await coachingQuestionaryService.Save(coachingQuestionary, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CoachingQuestionary>(coachingQuestionary);

            Result childResult = null;

            if(coachingQuestionary.ListOfCoachingQuestionaryAnswered.CheckList())
            {
                coachingQuestionary.ListOfCoachingQuestionaryAnswered.ForEach(i => i.CoachingQuestionary.Id = result.Id);

                childResult = await coachingQuestionary.ListOfCoachingQuestionaryAnswered.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CoachingQuestionary>(coachingQuestionary);
                }
            }

            if(coachingQuestionary.ListOfCoachingQuestionaryDetail.CheckList())
            {
                coachingQuestionary.ListOfCoachingQuestionaryDetail.ForEach(i => i.CoachingQuestionary.Id = result.Id);

                childResult = await coachingQuestionary.ListOfCoachingQuestionaryDetail.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CoachingQuestionary>(coachingQuestionary);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CoachingQuestionary>(coachingQuestionary);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CoachingQuestionary>> SaveCollection(this List<CoachingQuestionary> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CoachingQuestionary> result = new SuccessfulDataResult<CoachingQuestionary>();

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
