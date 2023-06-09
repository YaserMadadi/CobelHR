using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface ISubjectService : IService<Subject>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int subject_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit);
    }
}
