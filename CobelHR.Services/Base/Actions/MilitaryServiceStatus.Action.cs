
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class MilitaryServiceStatus_Action
    {
		
        public static async Task<DataResult<MilitaryServiceStatus>> SaveAttached(this MilitaryServiceStatus militaryServiceStatus, UserCredit userCredit)
        {
            var permissionType = militaryServiceStatus.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(militaryServiceStatus.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MilitaryServiceStatus>(-1, "You don't have Save Permission for ''MilitaryServiceStatus''", militaryServiceStatus);

            return await militaryServiceStatus.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MilitaryServiceStatus>> SaveAttached(this MilitaryServiceStatus militaryServiceStatus, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMilitaryServiceStatusService militaryServiceStatusService = new MilitaryServiceStatusService();

            var result = await militaryServiceStatusService.Save(militaryServiceStatus, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MilitaryServiceStatus>(militaryServiceStatus);

            Result childResult = null;

            if(militaryServiceStatus.ListOfMilitaryService.CheckList())
            {
                militaryServiceStatus.ListOfMilitaryService.ForEach(i => i.MilitaryServiceStatus.Id = result.Id);

                childResult = await militaryServiceStatus.ListOfMilitaryService.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MilitaryServiceStatus>(militaryServiceStatus);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<MilitaryServiceStatus>(militaryServiceStatus);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MilitaryServiceStatus>> SaveCollection(this List<MilitaryServiceStatus> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MilitaryServiceStatus> result = new SuccessfulDataResult<MilitaryServiceStatus>();

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
