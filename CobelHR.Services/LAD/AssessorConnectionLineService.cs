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
    public class AssessorConnectionLineService : Service<AssessorConnectionLine>, IAssessorConnectionLineService
    {
        public AssessorConnectionLineService() : base()
        {
        }

        public override async Task<DataResult<AssessorConnectionLine>> SaveAttached(AssessorConnectionLine assessorConnectionLine, UserCredit userCredit)
        {
            return await assessorConnectionLine.SaveAttached(userCredit);
        }

        
    }
}