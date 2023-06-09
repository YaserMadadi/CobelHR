using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface ITargetSettingTypeService : IService<TargetSettingType>
    {
        DataResult<List<TargetSetting>> CollectionOfTargetSetting(int targetSettingType_Id, TargetSetting targetSetting, UserCredit userCredit);
    }
}
