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
    public class FinalAppraiseService : Service<FinalAppraise>, IFinalAppraiseService
    {
        public FinalAppraiseService() : base()
        {
        }

        public override async Task<DataResult<FinalAppraise>> SaveAttached(FinalAppraise finalAppraise, UserCredit userCredit)
        {
            return await finalAppraise.SaveAttached(userCredit);
        }

        
    }
}