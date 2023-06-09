using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IIndividualDevelopmentPlanService : IService<IndividualDevelopmentPlan>
    {
        DataResult<List<DevelopmentPlanCompetency>> CollectionOfDevelopmentPlanCompetency(int individualDevelopmentPlan_Id, DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit);
    }
}
