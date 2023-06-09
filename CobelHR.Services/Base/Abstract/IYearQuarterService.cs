using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.LAD;



namespace CobelHR.Services.Base.Abstract
{
    public interface IYearQuarterService : IService<YearQuarter>
    {
        DataResult<List<AssessmentTraining>> CollectionOfAssessmentTraining_DeadLine(int yearQuarter_Id, AssessmentTraining assessmentTraining, UserCredit userCredit);
    }
}
