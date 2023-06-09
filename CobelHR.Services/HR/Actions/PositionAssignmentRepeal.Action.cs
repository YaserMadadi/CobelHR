
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
    public static class PositionAssignmentRepeal_Action
    {
		
        public static async Task<DataResult<PositionAssignmentRepeal>> SaveAttached(this PositionAssignmentRepeal positionAssignmentRepeal, UserCredit userCredit)
        {
            var permissionType = positionAssignmentRepeal.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(positionAssignmentRepeal.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PositionAssignmentRepeal>(-1, "You don't have Save Permission for ''PositionAssignmentRepeal''", positionAssignmentRepeal);

            return await positionAssignmentRepeal.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PositionAssignmentRepeal>> SaveAttached(this PositionAssignmentRepeal positionAssignmentRepeal, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPositionAssignmentRepealService positionAssignmentRepealService = new PositionAssignmentRepealService();

            var result = await positionAssignmentRepealService.Save(positionAssignmentRepeal, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PositionAssignmentRepeal>(positionAssignmentRepeal);

            

            if (depth > 0)

                return new SuccessfulDataResult<PositionAssignmentRepeal>(positionAssignmentRepeal);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PositionAssignmentRepeal>> SaveCollection(this List<PositionAssignmentRepeal> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PositionAssignmentRepeal> result = new SuccessfulDataResult<PositionAssignmentRepeal>();

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
