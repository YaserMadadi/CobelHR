
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
    public static class PositionDivision_Action
    {
		
        public static async Task<DataResult<PositionDivision>> SaveAttached(this PositionDivision positionDivision, UserCredit userCredit)
        {
            var permissionType = positionDivision.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(positionDivision.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PositionDivision>(-1, "You don't have Save Permission for ''PositionDivision''", positionDivision);

            return await positionDivision.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PositionDivision>> SaveAttached(this PositionDivision positionDivision, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPositionDivisionService positionDivisionService = new PositionDivisionService();

            var result = await positionDivisionService.Save(positionDivision, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PositionDivision>(positionDivision);

            Result childResult = null;

            if(positionDivision.ListOfPosition.CheckList())
            {
                positionDivision.ListOfPosition.ForEach(i => i.PositionDivision.Id = result.Id);

                childResult = await positionDivision.ListOfPosition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<PositionDivision>(positionDivision);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<PositionDivision>(positionDivision);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PositionDivision>> SaveCollection(this List<PositionDivision> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PositionDivision> result = new SuccessfulDataResult<PositionDivision>();

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
