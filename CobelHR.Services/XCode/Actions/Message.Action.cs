
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.XCode;
using CobelHR.Services.XCode.Abstract;


namespace CobelHR.Services.XCode.Actions
{
    public static class Message_Action
    {
		
        public static async Task<DataResult<Message>> SaveAttached(this Message message, UserCredit userCredit)
        {
            var permissionType = message.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(message.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Message>(-1, "You don't have Save Permission for ''Message''", message);

            return await message.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Message>> SaveAttached(this Message message, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMessageService messageService = new MessageService();

            var result = await messageService.Save(message, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Message>(message);

            

            if (depth > 0)

                return new SuccessfulDataResult<Message>(message);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Message>> SaveCollection(this List<Message> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Message> result = new SuccessfulDataResult<Message>();

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
