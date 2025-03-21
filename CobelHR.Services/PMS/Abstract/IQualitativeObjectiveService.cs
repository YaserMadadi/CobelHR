using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IQualitativeObjectiveService : IService<QualitativeObjective>
    {
        DataResult<List<QualitativeKPI>> CollectionOfQualitativeKPI(int qualitativeObjective_Id, QualitativeKPI qualitativeKPI, UserCredit userCredit);
    }
}
