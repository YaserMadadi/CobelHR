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
    public class ConfigObjectiveService : Service<ConfigObjective>, IConfigObjectiveService
    {
        public ConfigObjectiveService() : base()
        {
        }

        public override async Task<DataResult<ConfigObjective>> SaveAttached(ConfigObjective configObjective, UserCredit userCredit)
        {
            return await configObjective.SaveAttached(userCredit);
        }

        public DataResult<List<ConfigKPI>> CollectionOfConfigKPI(int configObjective_Id, ConfigKPI configKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS.Pharma].[ConfigObjective.CollectionOfConfigKPI]";

            return this.CollectionOf<ConfigKPI>(procedureName,
                                                    new SqlParameter("@Id",configObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", configKPI.ToJson()));
        }
    }
}