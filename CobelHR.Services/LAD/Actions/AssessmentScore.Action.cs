
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
    public static class AssessmentScore_Action
    {
		
        public static async Task<DataResult<AssessmentScore>> SaveAttached(this AssessmentScore assessmentScore, UserCredit userCredit)
        {
            var permissionType = assessmentScore.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessmentScore.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AssessmentScore>(-1, "You don't have Save Permission for ''AssessmentScore''", assessmentScore);

            return await assessmentScore.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AssessmentScore>> SaveAttached(this AssessmentScore assessmentScore, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessmentScoreService assessmentScoreService = new AssessmentScoreService();

            var result = await assessmentScoreService.Save(assessmentScore, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AssessmentScore>(assessmentScore);

            

            if (depth > 0)

                return new SuccessfulDataResult<AssessmentScore>(assessmentScore);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AssessmentScore>> SaveCollection(this List<AssessmentScore> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AssessmentScore> result = new SuccessfulDataResult<AssessmentScore>();

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
