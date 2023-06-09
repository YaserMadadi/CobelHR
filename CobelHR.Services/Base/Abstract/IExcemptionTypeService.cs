using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IExcemptionTypeService : IService<ExcemptionType>
    {
        DataResult<List<MilitaryServiceExcemption>> CollectionOfMilitaryServiceExcemption(int excemptionType_Id, MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit);
    }
}
