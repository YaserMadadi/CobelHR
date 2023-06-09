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
    public class ConfigTargetSettingService : Service<ConfigTargetSetting>, IConfigTargetSettingService
    {
        public ConfigTargetSettingService() : base()
        {
        }

        public override async Task<DataResult<ConfigTargetSetting>> SaveAttached(ConfigTargetSetting configTargetSetting, UserCredit userCredit)
        {
            return await configTargetSetting.SaveAttached(userCredit);
        }

        public DataResult<List<ConfigQualitativeObjective>> CollectionOfConfigQualitativeObjective(int configTargetSetting_Id, ConfigQualitativeObjective configQualitativeObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[ConfigTargetSetting.CollectionOfConfigQualitativeObjective]";

            return this.CollectionOf<ConfigQualitativeObjective>(procedureName,
                                                    new SqlParameter("@Id",configTargetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", configQualitativeObjective.ToJson()));
        }
    }
}