using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;

namespace CobelHR.Services.Base.HR
{
    public class DevelopmentPlanTypeService : Service<DevelopmentPlanType>, IDevelopmentPlanTypeService
    {
        public DevelopmentPlanTypeService() : base()
        {
        }

        public override async Task<DataResult<DevelopmentPlanType>> SaveAttached(DevelopmentPlanType developmentPlanType, UserCredit userCredit)
        {
            return await developmentPlanType.SaveAttached(userCredit);
        }

        
    }
}