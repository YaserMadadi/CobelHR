using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IBehavioralObjectiveService : IService<BehavioralObjective>
    {
        DataResult<List<BehavioralKPI>> CollectionOfBehavioralKPI(int behavioralObjective_Id, BehavioralKPI behavioralKPI, UserCredit userCredit);
    }
}
