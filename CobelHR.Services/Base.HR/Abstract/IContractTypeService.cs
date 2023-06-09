using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IContractTypeService : IService<ContractType>
    {
        DataResult<List<Contract>> CollectionOfContract(int contractType_Id, Contract contract, UserCredit userCredit);
    }
}
