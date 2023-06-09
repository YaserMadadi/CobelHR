using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class ContractTypeService : Service<ContractType>, IContractTypeService
    {
        public ContractTypeService() : base()
        {
        }

        public override async Task<DataResult<ContractType>> SaveAttached(ContractType contractType, UserCredit userCredit)
        {
            return await contractType.SaveAttached(userCredit);
        }

        public DataResult<List<Contract>> CollectionOfContract(int contractType_Id, Contract contract, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[ContractType.CollectionOfContract]";

            return this.CollectionOf<Contract>(procedureName,
                                                    new SqlParameter("@Id",contractType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", contract.ToJson()));
        }
    }
}