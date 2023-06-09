
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
    public static class Assessment_Action
    {
		
        public static async Task<DataResult<Assessment>> SaveAttached(this Assessment assessment, UserCredit userCredit)
        {
            var permissionType = assessment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Assessment>(-1, "You don't have Save Permission for ''Assessment''", assessment);

            return await assessment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Assessment>> SaveAttached(this Assessment assessment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessmentService assessmentService = new AssessmentService();

            var result = await assessmentService.Save(assessment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Assessment>(assessment);

            Result childResult = null;

            if(assessment.ListOfAssessmentCoaching.CheckList())
            {
                assessment.ListOfAssessmentCoaching.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfAssessmentCoaching.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfAssessmentScore.CheckList())
            {
                assessment.ListOfAssessmentScore.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfAssessmentScore.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfAssessmentTraining.CheckList())
            {
                assessment.ListOfAssessmentTraining.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfAssessmentTraining.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfCoachingQuestionary.CheckList())
            {
                assessment.ListOfCoachingQuestionary.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfCoachingQuestionary.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfConclusion.CheckList())
            {
                assessment.ListOfConclusion.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfConclusion.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfDevelopmentGoal.CheckList())
            {
                assessment.ListOfDevelopmentGoal.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfDevelopmentGoal.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfFeedbackSession.CheckList())
            {
                assessment.ListOfFeedbackSession.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfFeedbackSession.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfPromotionAssessment.CheckList())
            {
                assessment.ListOfPromotionAssessment.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfPromotionAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }

            if(assessment.ListOfRotationAssessment.CheckList())
            {
                assessment.ListOfRotationAssessment.ForEach(i => i.Assessment.Id = result.Id);

                childResult = await assessment.ListOfRotationAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessment>(assessment);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Assessment>(assessment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Assessment>> SaveCollection(this List<Assessment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Assessment> result = new SuccessfulDataResult<Assessment>();

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
