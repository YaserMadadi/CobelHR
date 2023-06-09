using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Actions;
using CobelHR.Services.PMS.Pharma.Abstract;

namespace CobelHR.Services.PMS.Pharma
{
    public class AppraiseService : Service<Appraise>, IAppraiseService
    {
        public AppraiseService() : base()
        {
        }

        public override async Task<DataResult<Appraise>> SaveAttached(Appraise appraise, UserCredit userCredit)
        {
            return await appraise.SaveAttached(userCredit);
        }

        
    }
}