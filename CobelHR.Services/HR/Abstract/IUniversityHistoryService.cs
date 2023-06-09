using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IUniversityHistoryService : IService<UniversityHistory>
    {
        DataResult<List<UniversityTerminate>> CollectionOfUniversityTerminate(int universityHistory_Id, UniversityTerminate universityTerminate, UserCredit userCredit);
    }
}
