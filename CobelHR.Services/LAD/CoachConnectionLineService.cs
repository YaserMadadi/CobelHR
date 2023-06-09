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
    public class CoachConnectionLineService : Service<CoachConnectionLine>, ICoachConnectionLineService
    {
        public CoachConnectionLineService() : base()
        {
        }

        public override async Task<DataResult<CoachConnectionLine>> SaveAttached(CoachConnectionLine coachConnectionLine, UserCredit userCredit)
        {
            return await coachConnectionLine.SaveAttached(userCredit);
        }

        
    }
}