
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
    public static class AssessmentCoaching_Action
    {
		
        public static async Task<DataResult<AssessmentCoaching>> SaveAttached(this AssessmentCoaching assessmentCoaching, UserCredit userCredit)
        {
            var permissionType = assessmentCoaching.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessmentCoaching.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AssessmentCoaching>(-1, "You don't have Save Permission for ''AssessmentCoaching''", assessmentCoaching);

            return await assessmentCoaching.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AssessmentCoaching>> SaveAttached(this AssessmentCoaching assessmentCoaching, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessmentCoachingService assessmentCoachingService = new AssessmentCoachingService();

            var result = await assessmentCoachingService.Save(assessmentCoaching, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AssessmentCoaching>(assessmentCoaching);

            

            if (depth > 0)

                return new SuccessfulDataResult<AssessmentCoaching>(assessmentCoaching);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AssessmentCoaching>> SaveCollection(this List<AssessmentCoaching> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AssessmentCoaching> result = new SuccessfulDataResult<AssessmentCoaching>();

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
