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
    public class CoachingQuestionaryService : Service<CoachingQuestionary>, ICoachingQuestionaryService
    {
        public CoachingQuestionaryService() : base()
        {
        }

        public override async Task<DataResult<CoachingQuestionary>> SaveAttached(CoachingQuestionary coachingQuestionary, UserCredit userCredit)
        {
            return await coachingQuestionary.SaveAttached(userCredit);
        }

        public DataResult<List<CoachingQuestionaryAnswered>> CollectionOfCoachingQuestionaryAnswered(int coachingQuestionary_Id, CoachingQuestionaryAnswered coachingQuestionaryAnswered, UserCredit userCredit)
        {
            var procedureName = "[LAD].[CoachingQuestionary.CollectionOfCoachingQuestionaryAnswered]";

            return this.CollectionOf<CoachingQuestionaryAnswered>(procedureName,
                                                    new SqlParameter("@Id",coachingQuestionary_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionaryAnswered.ToJson()));
        }

		public DataResult<List<CoachingQuestionaryDetail>> CollectionOfCoachingQuestionaryDetail(int coachingQuestionary_Id, CoachingQuestionaryDetail coachingQuestionaryDetail, UserCredit userCredit)
        {
            var procedureName = "[LAD].[CoachingQuestionary.CollectionOfCoachingQuestionaryDetail]";

            return this.CollectionOf<CoachingQuestionaryDetail>(procedureName,
                                                    new SqlParameter("@Id",coachingQuestionary_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingQuestionaryDetail.ToJson()));
        }
    }
}