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
using CobelHR.Entities.Base.PMS;

namespace CobelHR.Services.PMS
{
    public class TargetSettingPhaseService : Service<TargetSettingPhase>, ITargetSettingPhaseService
    {
        public TargetSettingPhaseService() : base()
        {
        }

        //public override async Task<DataResult<TargetSettingPhase>> SaveAttached(TargetSettingPhase targetSettingPhase, UserCredit userCredit)
        //{
        //    return await targetSettingPhase.SaveAttached(userCredit);
        //}

        
    }
}