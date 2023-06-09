using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IInclusiveTypeService : IService<InclusiveType>
    {
        DataResult<List<MilitaryServiceInclusive>> CollectionOfMilitaryServiceInclusive(int inclusiveType_Id, MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit);
    }
}
