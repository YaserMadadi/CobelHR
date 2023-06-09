
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
    public static class Habitancy_Action
    {
		
        public static async Task<DataResult<Habitancy>> SaveAttached(this Habitancy habitancy, UserCredit userCredit)
        {
            var permissionType = habitancy.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(habitancy.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Habitancy>(-1, "You don't have Save Permission for ''Habitancy''", habitancy);

            return await habitancy.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Habitancy>> SaveAttached(this Habitancy habitancy, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IHabitancyService habitancyService = new HabitancyService();

            var result = await habitancyService.Save(habitancy, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Habitancy>(habitancy);

            

            if (depth > 0)

                return new SuccessfulDataResult<Habitancy>(habitancy);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Habitancy>> SaveCollection(this List<Habitancy> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Habitancy> result = new SuccessfulDataResult<Habitancy>();

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
