using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IEducationSystemService : IService<EducationSystem>
    {
        DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int educationSystem_Id, UniversityHistory universityHistory, UserCredit userCredit);
    }
}
