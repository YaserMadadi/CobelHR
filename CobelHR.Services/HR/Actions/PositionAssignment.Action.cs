
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
    public static class PositionAssignment_Action
    {
		
        public static async Task<DataResult<PositionAssignment>> SaveAttached(this PositionAssignment positionAssignment, UserCredit userCredit)
        {
            var permissionType = positionAssignment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(positionAssignment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PositionAssignment>(-1, "You don't have Save Permission for ''PositionAssignment''", positionAssignment);

            return await positionAssignment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PositionAssignment>> SaveAttached(this PositionAssignment positionAssignment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPositionAssignmentService positionAssignmentService = new PositionAssignmentService();

            var result = await positionAssignmentService.Save(positionAssignment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PositionAssignment>(positionAssignment);

            Result childResult = null;

            if(positionAssignment.ListOfPositionAssignmentRepeal.CheckList())
            {
                positionAssignment.ListOfPositionAssignmentRepeal.ForEach(i => i.PositionAssignment.Id = result.Id);

                childResult = await positionAssignment.ListOfPositionAssignmentRepeal.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionAssignment>(positionAssignment);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<PositionAssignment>(positionAssignment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PositionAssignment>> SaveCollection(this List<PositionAssignment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PositionAssignment> result = new SuccessfulDataResult<PositionAssignment>();

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
