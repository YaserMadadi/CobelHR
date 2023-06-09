using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Actions;
using CobelHR.Services.Core.Abstract;

namespace CobelHR.Services.Core
{
    public class LogService : Service<Log>, ILogService
    {
        public LogService() : base()
        {
        }

        public override async Task<DataResult<Log>> SaveAttached(Log log, UserCredit userCredit)
        {
            return await log.SaveAttached(userCredit);
        }

        
    }
}