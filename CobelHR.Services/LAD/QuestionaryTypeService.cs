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
    public class QuestionaryTypeService : Service<QuestionaryType>, IQuestionaryTypeService
    {
        public QuestionaryTypeService() : base()
        {
        }

        public override async Task<DataResult<QuestionaryType>> SaveAttached(QuestionaryType questionaryType, UserCredit userCredit)
        {
            return await questionaryType.SaveAttached(userCredit);
        }

        public DataResult<List<CoachingQuestionary>> CollectionOfCoachingQuestionary(int questionaryType_Id, CoachingQuestionary coachingQuestionary, UserCredit userCredit)
        {
            var procedureName = "[LAD].[QuestionaryType.CollectionOfCoachingQuestionary]";

            return this.CollectionOf<CoachingQuestionary>(procedureName,
                                                    new SqlParameter("@Id",questionaryType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionary.ToJson()));
        }

		public DataResult<List<QuestionaryItem>> CollectionOfQuestionaryItem(int questionaryType_Id, QuestionaryItem questionaryItem, UserCredit userCredit)
        {
            var procedureName = "[LAD].[QuestionaryType.CollectionOfQuestionaryItem]";

            return this.CollectionOf<QuestionaryItem>(procedureName,
                                                    new SqlParameter("@Id",questionaryType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", questionaryItem.ToJson()));
        }
    }
}