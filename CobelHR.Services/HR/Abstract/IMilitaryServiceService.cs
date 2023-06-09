using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IMilitaryServiceService : IService<MilitaryService>
    {
        DataResult<List<MilitaryServiceExcemption>> CollectionOfMilitaryServiceExcemption(int militaryService_Id, MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit);

		DataResult<List<MilitaryServiceInclusive>> CollectionOfMilitaryServiceInclusive(int militaryService_Id, MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit);
    }
}
