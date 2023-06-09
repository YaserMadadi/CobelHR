using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class ContractService : Service<Contract>, IContractService
    {
        public ContractService() : base()
        {
        }

        public override async Task<DataResult<Contract>> SaveAttached(Contract contract, UserCredit userCredit)
        {
            return await contract.SaveAttached(userCredit);
        }

        
    }
}