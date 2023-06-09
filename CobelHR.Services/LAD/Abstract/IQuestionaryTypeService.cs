using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IQuestionaryTypeService : IService<QuestionaryType>
    {
        DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary(int questionaryType_Id, CoachingQuestionary coachingQuestionary, UserCredit userCredit);

		DataResult<List<QuestionaryItem>> CollectionOfQuestionaryItem(int questionaryType_Id, QuestionaryItem questionaryItem, UserCredit userCredit);
    }
}
