using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IDesirableSituationService : IService<DesirableSituation>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int desirableSituation_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit);
    }
}
