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
    public class MaritalInfoService : Service<MaritalInfo>, IMaritalInfoService
    {
        public MaritalInfoService() : base()
        {
        }

        public override async Task<DataResult<MaritalInfo>> SaveAttached(MaritalInfo maritalInfo, UserCredit userCredit)
        {
            return await maritalInfo.SaveAttached(userCredit);
        }

        
    }
}