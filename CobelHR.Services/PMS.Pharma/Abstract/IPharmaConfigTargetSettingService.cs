using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;


namespace CobelHR.Services.PMS.Pharma.Abstract
{
    public interface IPharmaConfigTargetSettingService : IService<PharmaConfigTargetSetting>
    {
        DataResult<List<ConfigObjective>> CollectionOfConfigObjective(int configTargetSetting_Id, ConfigObjective configObjective, UserCredit userCredit);
    }
}
