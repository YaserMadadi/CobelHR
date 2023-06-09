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
    public class DevelopmentGoalService : Service<DevelopmentGoal>, IDevelopmentGoalService
    {
        public DevelopmentGoalService() : base()
        {
        }

        public override async Task<DataResult<DevelopmentGoal>> SaveAttached(DevelopmentGoal developmentGoal, UserCredit userCredit)
        {
            return await developmentGoal.SaveAttached(userCredit);
        }

        
    }
}