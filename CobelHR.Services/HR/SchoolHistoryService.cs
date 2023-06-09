using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class SchoolHistoryService : Service<SchoolHistory>, ISchoolHistoryService
    {
        public SchoolHistoryService() : base()
        {
        }

        public override async Task<DataResult<SchoolHistory>> SaveAttached(SchoolHistory schoolHistory, UserCredit userCredit)
        {
            return await schoolHistory.SaveAttached(userCredit);
        }

        
    }
}