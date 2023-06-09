
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Abstract;


namespace CobelHR.Services.Core.Actions
{
    public static class CommandParameter_Action
    {
		
        public static async Task<DataResult<CommandParameter>> SaveAttached(this CommandParameter commandParameter, UserCredit userCredit)
        {
            var permissionType = commandParameter.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(commandParameter.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CommandParameter>(-1, "You don't have Save Permission for ''CommandParameter''", commandParameter);

            return await commandParameter.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CommandParameter>> SaveAttached(this CommandParameter commandParameter, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICommandParameterService CommandParameterService = new CommandParameterService();

            var result = await CommandParameterService.Save(commandParameter, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CommandParameter>(commandParameter);

            if (depth > 0)

                return new SuccessfulDataResult<CommandParameter>(commandParameter);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CommandParameter>> SaveCollection(this List<CommandParameter> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CommandParameter> result = new SuccessfulDataResult<CommandParameter>();

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
