using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IUniversityService : IService<University>
    {
        DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int university_Id, UniversityHistory universityHistory, UserCredit userCredit);
    }
}
