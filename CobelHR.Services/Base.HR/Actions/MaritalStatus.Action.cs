
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
    public static class MaritalStatus_Action
    {
		
        public static async Task<DataResult<MaritalStatus>> SaveAttached(this MaritalStatus maritalStatus, UserCredit userCredit)
        {
            var permissionType = maritalStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(maritalStatus.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MaritalStatus>(-1, "You don't have Save Permission for ''MaritalStatus''", maritalStatus);

            return await maritalStatus.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MaritalStatus>> SaveAttached(this MaritalStatus maritalStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMaritalStatusService maritalStatusService = new MaritalStatusService();

            var result = await maritalStatusService.Save(maritalStatus, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MaritalStatus>(maritalStatus);

            Result childResult = null;

            if(maritalStatus.ListOfPerson.CheckList())
            {
                maritalStatus.ListOfPerson.ForEach(i => i.MaritalStatus.Id = result.Id);

                childResult = await maritalStatus.ListOfPerson.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MaritalStatus>(maritalStatus);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<MaritalStatus>(maritalStatus);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MaritalStatus>> SaveCollection(this List<MaritalStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MaritalStatus> result = new SuccessfulDataResult<MaritalStatus>();

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
