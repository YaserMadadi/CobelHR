using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IAssessmentService : IService<Assessment>
    {
        DataResult<List<AssessmentCoaching>> CollectionOfAssessmentCoaching(int assessment_Id, AssessmentCoaching assessmentCoaching, UserCredit userCredit);

		DataResult<List<AssessmentScore>> CollectionOfAssessmentScore(int assessment_Id, AssessmentScore assessmentScore, UserCredit userCredit);

		DataResult<List<AssessmentTraining>> CollectionOfAssessmentTraining(int assessment_Id, AssessmentTraining assessmentTraining, UserCredit userCredit);

		DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary(int assessment_Id, CoachingQuestionary coachingQuestionary, UserCredit userCredit);

		DataResult<List<Conclusion>> CollectionOfConclusion(int assessment_Id, Conclusion conclusion, UserCredit userCredit);

		DataResult<List<DevelopmentGoal>> CollectionOfDevelopmentGoal(int assessment_Id, DevelopmentGoal developmentGoal, UserCredit userCredit);

		DataResult<List<FeedbackSession>> CollectionOfFeedbackSession(int assessment_Id, FeedbackSession feedbackSession, UserCredit userCredit);

		DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment(int assessment_Id, PromotionAssessment promotionAssessment, UserCredit userCredit);

		DataResult<List<RotationAssessment>> CollectionOfRotationAssessment(int assessment_Id, RotationAssessment rotationAssessment, UserCredit userCredit);
    }
}
