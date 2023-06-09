using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface ICompetencyItemKPIService : IService<CompetencyItemKPI>
    {
        DataResult<List<BehavioralKPI>> CollectionOfBehavioralKPI(int competencyItemKPI_Id, BehavioralKPI behavioralKPI, UserCredit userCredit);
    }
}
