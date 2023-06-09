
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
    public static class AssessmentTraining_Action
    {
		
        public static async Task<DataResult<AssessmentTraining>> SaveAttached(this AssessmentTraining assessmentTraining, UserCredit userCredit)
        {
            var permissionType = assessmentTraining.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessmentTraining.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AssessmentTraining>(-1, "You don't have Save Permission for ''AssessmentTraining''", assessmentTraining);

            return await assessmentTraining.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AssessmentTraining>> SaveAttached(this AssessmentTraining assessmentTraining, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessmentTrainingService assessmentTrainingService = new AssessmentTrainingService();

            var result = await assessmentTrainingService.Save(assessmentTraining, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AssessmentTraining>(assessmentTraining);

            

            if (depth > 0)

                return new SuccessfulDataResult<AssessmentTraining>(assessmentTraining);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AssessmentTraining>> SaveCollection(this List<AssessmentTraining> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AssessmentTraining> result = new SuccessfulDataResult<AssessmentTraining>();

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
