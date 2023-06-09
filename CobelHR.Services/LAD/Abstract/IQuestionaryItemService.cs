using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IQuestionaryItemService : IService<QuestionaryItem>
    {
        DataResult<List<CoachingQuestionaryAnswered>> CollectionOfCoachingQuestionaryAnswered(int questionaryItem_Id, CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit);
    }
}
