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
    public class QuestionaryItemService : Service<QuestionaryItem>, IQuestionaryItemService
    {
        public QuestionaryItemService() : base()
        {
        }

        public override async Task<DataResult<QuestionaryItem>> SaveAttached(QuestionaryItem questionaryItem, UserCredit userCredit)
        {
            return await questionaryItem.SaveAttached(userCredit);
        }

        public DataResult<List<CoachingQuestionaryAnswered>> CollectionOfCoachingQuestionaryAnswered(int questionaryItem_Id, CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit)
        {
            var procedureName = "[LAD].[QuestionaryItem.CollectionOfCoachingQuestionaryAnswered]";

            return this.CollectionOf<CoachingQuestionaryAnswered>(procedureName,
                                                    new SqlParameter("@Id",questionaryItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionaryAnswered.ToJson()));
        }
    }
}