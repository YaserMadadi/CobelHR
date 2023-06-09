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
    public class ConfigKPIService : Service<ConfigKPI>, IConfigKPIService
    {
        public ConfigKPIService() : base()
        {
        }

        public override async Task<DataResult<ConfigKPI>> SaveAttached(ConfigKPI configKPI, UserCredit userCredit)
        {
            return await configKPI.SaveAttached(userCredit);
        }

        
    }
}