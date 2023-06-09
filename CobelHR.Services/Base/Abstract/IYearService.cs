using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.Abstract
{
    public interface IYearService : IService<Year>
    {
        DataResult<List<TargetSetting>> CollectionOfTargetSetting(int year_Id, TargetSetting targetSetting, UserCredit userCredit);

		DataResult<List<Vision>> CollectionOfVision(int year_Id, Vision vision, UserCredit userCredit);

		DataResult<List<YearQuarter>> CollectionOfYearQuarter(int year_Id, YearQuarter yearQuarter, UserCredit userCredit);
    }
}
