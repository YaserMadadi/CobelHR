using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IMilitaryServiceStatusService : IService<MilitaryServiceStatus>
    {
        DataResult<List<MilitaryService>> CollectionOfMilitaryService(int militaryServiceStatus_Id, MilitaryService militaryService, UserCredit userCredit);
    }
}
