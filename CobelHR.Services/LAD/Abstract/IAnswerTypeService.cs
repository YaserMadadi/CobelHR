using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IAnswerTypeService : IService<AnswerType>
    {
        DataResult<List<AnswerTypeItem>> CollectionOfAnswerTypeItem(int answerType_Id, AnswerTypeItem answerTypeItem, UserCredit userCredit);

		DataResult<List<QuestionaryItem>> CollectionOfQuestionaryItem(int answerType_Id, QuestionaryItem questionaryItem, UserCredit userCredit);
    }
}
