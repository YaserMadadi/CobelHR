using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IDevelopmentPlanPriorityService : IService<DevelopmentPlanPriority>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan_Priority(int developmentPlanPriority_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit);
    }
}
