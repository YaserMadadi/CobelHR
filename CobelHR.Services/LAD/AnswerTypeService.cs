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
    public class AnswerTypeService : Service<AnswerType>, IAnswerTypeService
    {
        public AnswerTypeService() : base()
        {
        }

        public override async Task<DataResult<AnswerType>> SaveAttached(AnswerType answerType, UserCredit userCredit)
        {
            return await answerType.SaveAttached(userCredit);
        }

        public DataResult<List<AnswerTypeItem>> CollectionOfAnswerTypeItem(int answerType_Id, AnswerTypeItem answerTypeItem, UserCredit userCredit)
        {
            var procedureName = "[LAD].[AnswerType.CollectionOfAnswerTypeItem]";

            return this.CollectionOf<AnswerTypeItem>(procedureName,
                                                    new SqlParameter("@Id",answerType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", answerTypeItem.ToJson()));
        }

		public DataResult<List<QuestionaryItem>> CollectionOfQuestionaryItem(int answerType_Id, QuestionaryItem questionaryItem, UserCredit userCredit)
        {
            var procedureName = "[LAD].[AnswerType.CollectionOfQuestionaryItem]";

            return this.CollectionOf<QuestionaryItem>(procedureName,
                                                    new SqlParameter("@Id",answerType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", questionaryItem.ToJson()));
        }
    }
}