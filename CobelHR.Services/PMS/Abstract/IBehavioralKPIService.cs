using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IBehavioralKPIService : IService<BehavioralKPI>
    {
        DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise(int behavioralKPI_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit);
    }
}
