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
    public class CoachService : Service<Coach>, ICoachService
    {
        public CoachService() : base()
        {
        }

        public override async Task<DataResult<Coach>> SaveAttached(Coach coach, UserCredit userCredit)
        {
            return await coach.SaveAttached(userCredit);
        }

        public DataResult<List<CoachConnectionLine>> CollectionOfCoachConnectionLine(int coach_Id, CoachConnectionLine coachConnectionLine, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Coach.CollectionOfCoachConnectionLine]";

            return this.CollectionOf<CoachConnectionLine>(procedureName,
                                                    new SqlParameter("@Id",coach_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachConnectionLine.ToJson()));
        }

		public DataResult<List<Coaching>> CollectionOfCoaching(int coach_Id, Coaching coaching, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Coach.CollectionOfCoaching]";

            return this.CollectionOf<Coaching>(procedureName,
                                                    new SqlParameter("@Id",coach_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coaching.ToJson()));
        }
    }
}