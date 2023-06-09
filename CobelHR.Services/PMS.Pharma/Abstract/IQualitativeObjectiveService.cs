using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;


namespace CobelHR.Services.PMS.Pharma.Abstract
{
    public interface IObjectiveService : IService<Objective>
    {
        DataResult<List<KPI>> CollectionOfKPI(int objective_Id, KPI kpi, UserCredit userCredit);
    }
}
