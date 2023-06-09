using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IQualitativeKPIService : IService<QualitativeKPI>
    {
        DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise(int qualitativeKPI_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit);
    }
}
