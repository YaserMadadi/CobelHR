using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;


namespace CobelHR.Services.PMS.Pharma.Abstract
{
    public interface IConfigObjectiveService : IService<ConfigObjective>
    {
        DataResult<List<ConfigKPI>> CollectionOfConfigKPI(int configObjective_Id, ConfigKPI configKPI, UserCredit userCredit);
    }
}
