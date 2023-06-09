using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IUniversityDegreeService : IService<UniversityDegree>
    {
        DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int universityDegree_Id, UniversityHistory universityHistory, UserCredit userCredit);
    }
}
