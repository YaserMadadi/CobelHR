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
    public class ConfigQualitativeObjectiveService : Service<ConfigQualitativeObjective>, IConfigQualitativeObjectiveService
    {
        public ConfigQualitativeObjectiveService() : base()
        {
        }

        public override async Task<DataResult<ConfigQualitativeObjective>> SaveAttached(ConfigQualitativeObjective configQualitativeObjective, UserCredit userCredit)
        {
            return await configQualitativeObjective.SaveAttached(userCredit);
        }

        public DataResult<List<ConfigQualitativeKPI>> CollectionOfConfigQualitativeKPI(int configQualitativeObjective_Id, ConfigQualitativeKPI configQualitativeKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[ConfigQualitativeObjective.CollectionOfConfigQualitativeKPI]";

            return this.CollectionOf<ConfigQualitativeKPI>(procedureName,
                                                    new SqlParameter("@Id",configQualitativeObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", configQualitativeKPI.ToJson()));
        }
    }
}