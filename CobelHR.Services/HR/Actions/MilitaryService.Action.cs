
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
    public static class MilitaryService_Action
    {
		
        public static async Task<DataResult<MilitaryService>> SaveAttached(this MilitaryService militaryService, UserCredit userCredit)
        {
            var permissionType = militaryService.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(militaryService.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MilitaryService>(-1, "You don't have Save Permission for ''MilitaryService''", militaryService);

            return await militaryService.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MilitaryService>> SaveAttached(this MilitaryService militaryService, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMilitaryServiceService militaryServiceService = new MilitaryServiceService();

            var result = await militaryServiceService.Save(militaryService, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MilitaryService>(militaryService);

            Result childResult = null;

            if(militaryService.ListOfMilitaryServiceExcemption.CheckList())
            {
                militaryService.ListOfMilitaryServiceExcemption.ForEach(i => i.MilitaryService.Id = result.Id);

                childResult = await militaryService.ListOfMilitaryServiceExcemption.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MilitaryService>(militaryService);
                }
            }

            if(militaryService.ListOfMilitaryServiceInclusive.CheckList())
            {
                militaryService.ListOfMilitaryServiceInclusive.ForEach(i => i.MilitaryService.Id = result.Id);

                childResult = await militaryService.ListOfMilitaryServiceInclusive.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MilitaryService>(militaryService);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<MilitaryService>(militaryService);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MilitaryService>> SaveCollection(this List<MilitaryService> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MilitaryService> result = new SuccessfulDataResult<MilitaryService>();

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
