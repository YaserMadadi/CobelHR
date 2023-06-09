using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface ICoachingService : IService<Coaching>
    {
        DataResult<List<AssessmentCoaching>> CollectionOfAssessmentCoaching(int coaching_Id, AssessmentCoaching assessmentCoaching, UserCredit userCredit);

		DataResult<List<CoachingSession>> CollectionOfCoachingSession(int coaching_Id, CoachingSession coachingSession, UserCredit userCredit);
    }
}
