
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
    public static class MilitaryServiceExcemption_Action
    {
		
        public static async Task<DataResult<MilitaryServiceExcemption>> SaveAttached(this MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit)
        {
            var permissionType = militaryServiceExcemption.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(militaryServiceExcemption.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MilitaryServiceExcemption>(-1, "You don't have Save Permission for ''MilitaryServiceExcemption''", militaryServiceExcemption);

            return await militaryServiceExcemption.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MilitaryServiceExcemption>> SaveAttached(this MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMilitaryServiceExcemptionService militaryServiceExcemptionService = new MilitaryServiceExcemptionService();

            var result = await militaryServiceExcemptionService.Save(militaryServiceExcemption, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MilitaryServiceExcemption>(militaryServiceExcemption);

            

            if (depth > 0)

                return new SuccessfulDataResult<MilitaryServiceExcemption>(militaryServiceExcemption);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MilitaryServiceExcemption>> SaveCollection(this List<MilitaryServiceExcemption> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MilitaryServiceExcemption> result = new SuccessfulDataResult<MilitaryServiceExcemption>();

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
