using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IConfigTargetSettingService : IService<ConfigTargetSetting>
    {
        DataResult<List<ConfigQualitativeObjective>> CollectionOfConfigQualitativeObjective(int configTargetSetting_Id, ConfigQualitativeObjective configQualitativeObjective, UserCredit userCredit);
    }
}
