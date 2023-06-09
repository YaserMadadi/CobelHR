
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class ContractType_Action
    {
		
        public static async Task<DataResult<ContractType>> SaveAttached(this ContractType contractType, UserCredit userCredit)
        {
            var permissionType = contractType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(contractType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ContractType>(-1, "You don't have Save Permission for ''ContractType''", contractType);

            return await contractType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ContractType>> SaveAttached(this ContractType contractType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IContractTypeService contractTypeService = new ContractTypeService();

            var result = await contractTypeService.Save(contractType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ContractType>(contractType);

            Result childResult = null;

            if(contractType.ListOfContract.CheckList())
            {
                contractType.ListOfContract.ForEach(i => i.ContractType.Id = result.Id);

                childResult = await contractType.ListOfContract.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ContractType>(contractType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ContractType>(contractType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ContractType>> SaveCollection(this List<ContractType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ContractType> result = new SuccessfulDataResult<ContractType>();

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
