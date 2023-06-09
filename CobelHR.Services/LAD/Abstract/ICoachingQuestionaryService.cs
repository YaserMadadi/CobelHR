using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface ICoachingQuestionaryService : IService<CoachingQuestionary>
    {
        DataResult<List<CoachingQuestionaryAnswered>> CollectionOfCoachingQuestionaryAnswered(int coachingQuestionary_Id, CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit);

		DataResult<List<CoachingQuestionaryDetail>> CollectionOfCoachingQuestionaryDetail(int coachingQuestionary_Id, CoachingQuestionaryDetail coachingQuestionaryDetail, UserCredit userCredit);
    }
}
