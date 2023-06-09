
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class Contract_Action
    {
		
        public static async Task<DataResult<Contract>> SaveAttached(this Contract contract, UserCredit userCredit)
        {
            var permissionType = contract.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(contract.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Contract>(-1, "You don't have Save Permission for ''Contract''", contract);

            return await contract.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Contract>> SaveAttached(this Contract contract, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IContractService contractService = new ContractService();

            var result = await contractService.Save(contract, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Contract>(contract);

            

            if (depth > 0)

                return new SuccessfulDataResult<Contract>(contract);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Contract>> SaveCollection(this List<Contract> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Contract> result = new SuccessfulDataResult<Contract>();

            foreach (var item in list)
            {
                result = await item.SaveAttached(userCredit, transaction, depth + 1);

                if (result.Id <= 0)

                    break;
            }

            return result;
        }
    }
}
