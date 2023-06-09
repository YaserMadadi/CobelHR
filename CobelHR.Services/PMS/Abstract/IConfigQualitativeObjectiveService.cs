using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IConfigQualitativeObjectiveService : IService<ConfigQualitativeObjective>
    {
        DataResult<List<ConfigQualitativeKPI>> CollectionOfConfigQualitativeKPI(int configQualitativeObjective_Id, ConfigQualitativeKPI configQualitativeKPI, UserCredit userCredit);
    }
}
