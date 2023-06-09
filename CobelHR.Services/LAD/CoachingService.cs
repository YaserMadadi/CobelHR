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
    public class CoachingService : Service<Coaching>, ICoachingService
    {
        public CoachingService() : base()
        {
        }

        public override async Task<DataResult<Coaching>> SaveAttached(Coaching coaching, UserCredit userCredit)
        {
            return await coaching.SaveAttached(userCredit);
        }

        public DataResult<List<AssessmentCoaching>> CollectionOfAssessmentCoaching(int coaching_Id, AssessmentCoaching assessmentCoaching, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Coaching.CollectionOfAssessmentCoaching]";

            return this.CollectionOf<AssessmentCoaching>(procedureName,
                                                    new SqlParameter("@Id",coaching_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentCoaching.ToJson()));
        }

		public DataResult<List<CoachingSession>> CollectionOfCoachingSession(int coaching_Id, CoachingSession coachingSession, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Coaching.CollectionOfCoachingSession]";

            return this.CollectionOf<CoachingSession>(procedureName,
                                                    new SqlParameter("@Id",coaching_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachingSession.ToJson()));
        }
    }
}