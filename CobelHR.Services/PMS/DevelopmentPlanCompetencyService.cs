using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.Services.PMS
{
    public class DevelopmentPlanCompetencyService : Service<DevelopmentPlanCompetency>, IDevelopmentPlanCompetencyService
    {
        public DevelopmentPlanCompetencyService() : base()
        {
        }

        public override async Task<DataResult<DevelopmentPlanCompetency>> SaveAttached(DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit)
        {
            return await developmentPlanCompetency.SaveAttached(userCredit);
        }

        
    }
}