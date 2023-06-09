using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;


namespace CobelHR.Services.Base.Abstract
{
    public interface IQuarterService : IService<Quarter>
    {
        DataResult<List<YearQuarter>> CollectionOfYearQuarter(int quarter_Id, YearQuarter yearQuarter, UserCredit userCredit);
    }
}
