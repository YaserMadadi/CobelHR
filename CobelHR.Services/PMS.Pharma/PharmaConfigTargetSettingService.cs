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
    public class PharmaConfigTargetSettingService : Service<PharmaConfigTargetSetting>, IPharmaConfigTargetSettingService
    {
        public PharmaConfigTargetSettingService() : base()
        {
        }

        public override async Task<DataResult<PharmaConfigTargetSetting>> SaveAttached(PharmaConfigTargetSetting configTargetSetting, UserCredit userCredit)
        {
            return await configTargetSetting.SaveAttached(userCredit);
        }

        public DataResult<List<ConfigObjective>> CollectionOfConfigObjective(int configTargetSetting_Id, ConfigObjective configObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS.Pharma].[ConfigTargetSetting.CollectionOfConfigObjective]";

            return this.CollectionOf<ConfigObjective>(procedureName,
                                                    new SqlParameter("@Id",configTargetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", configObjective.ToJson()));
        }
    }
}