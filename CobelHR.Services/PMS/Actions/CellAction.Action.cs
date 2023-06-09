
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class CellAction_Action
    {
		
        public static async Task<DataResult<CellAction>> SaveAttached(this CellAction cellAction, UserCredit userCredit)
        {
            var permissionType = cellAction.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(cellAction.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CellAction>(-1, "You don't have Save Permission for ''CellAction''", cellAction);

            return await cellAction.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CellAction>> SaveAttached(this CellAction cellAction, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICellActionService cellActionService = new CellActionService();

            var result = await cellActionService.Save(cellAction, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CellAction>(cellAction);

            

            if (depth > 0)

                return new SuccessfulDataResult<CellAction>(cellAction);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CellAction>> SaveCollection(this List<CellAction> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CellAction> result = new SuccessfulDataResult<CellAction>();

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
