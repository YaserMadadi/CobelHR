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
    public class FunctionalAppraiseService : Service<FunctionalAppraise>, IFunctionalAppraiseService
    {
        public FunctionalAppraiseService() : base()
        {
        }

        public override async Task<DataResult<FunctionalAppraise>> SaveAttached(FunctionalAppraise functionalAppraise, UserCredit userCredit)
        {
            return await functionalAppraise.SaveAttached(userCredit);
        }

        
    }
}