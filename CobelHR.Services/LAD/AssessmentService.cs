using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Actions;
using CobelHR.Services.LAD.Abstract;

namespace CobelHR.Services.LAD
{
    public class AssessmentService : Service<Assessment>, IAssessmentService
    {
        public AssessmentService() : base()
        {
        }

        public override async Task<DataResult<Assessment>> SaveAttached(Assessment assessment, UserCredit userCredit)
        {
            return await assessment.SaveAttached(userCredit);
        }

        public DataResult<List<AssessmentCoaching>> CollectionOfAssessmentCoaching(int assessment_Id, AssessmentCoaching assessmentCoaching, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfAssessmentCoaching]";

            return this.CollectionOf<AssessmentCoaching>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentCoaching.ToJson()));
        }

		public DataResult<List<AssessmentScore>> CollectionOfAssessmentScore(int assessment_Id, AssessmentScore assessmentScore, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfAssessmentScore]";

            return this.CollectionOf<AssessmentScore>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentScore.ToJson()));
        }

		public DataResult<List<AssessmentTraining>> CollectionOfAssessmentTraining(int assessment_Id, AssessmentTraining assessmentTraining, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfAssessmentTraining]";

            return this.CollectionOf<AssessmentTraining>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentTraining.ToJson()));
        }

		public DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary(int assessment_Id, CoachingQuestionary coachingQuestionary, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfCoachingQuestionary]";

            return this.CollectionOf<CoachingQuestionary>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionary.ToJson()));
        }

		public DataResult<List<Conclusion>> CollectionOfConclusion(int assessment_Id, Conclusion conclusion, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfConclusion]";

            return this.CollectionOf<Conclusion>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", conclusion.ToJson()));
        }

		public DataResult<List<DevelopmentGoal>> CollectionOfDevelopmentGoal(int assessment_Id, DevelopmentGoal developmentGoal, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfDevelopmentGoal]";

            return this.CollectionOf<DevelopmentGoal>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", developmentGoal.ToJson()));
        }

		public DataResult<List<FeedbackSession>> CollectionOfFeedbackSession(int assessment_Id, FeedbackSession feedbackSession, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfFeedbackSession]";

            return this.CollectionOf<FeedbackSession>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", feedbackSession.ToJson()));
        }

		public DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment(int assessment_Id, PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfPromotionAssessment]";

            return this.CollectionOf<PromotionAssessment>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", promotionAssessment.ToJson()));
        }

		public DataResult<List<RotationAssessment>> CollectionOfRotationAssessment(int assessment_Id, RotationAssessment rotationAssessment, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessment.CollectionOfRotationAssessment]";

            return this.CollectionOf<RotationAssessment>(procedureName,
                                                    new SqlParameter("@Id",assessment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", rotationAssessment.ToJson()));
        }
    }
}