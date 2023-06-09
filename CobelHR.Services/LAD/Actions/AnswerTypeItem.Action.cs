
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Abstract;


namespace CobelHR.Services.LAD.Actions
{
    public static class AnswerTypeItem_Action
    {
		
        public static async Task<DataResult<AnswerTypeItem>> SaveAttached(this AnswerTypeItem answerTypeItem, UserCredit userCredit)
        {
            var permissionType = answerTypeItem.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(answerTypeItem.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AnswerTypeItem>(-1, "You don't have Save Permission for ''AnswerTypeItem''", answerTypeItem);

            return await answerTypeItem.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AnswerTypeItem>> SaveAttached(this AnswerTypeItem answerTypeItem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAnswerTypeItemService answerTypeItemService = new AnswerTypeItemService();

            var result = await answerTypeItemService.Save(answerTypeItem, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AnswerTypeItem>(answerTypeItem);

            

            if (depth > 0)

                return new SuccessfulDataResult<AnswerTypeItem>(answerTypeItem);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AnswerTypeItem>> SaveCollection(this List<AnswerTypeItem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AnswerTypeItem> result = new SuccessfulDataResult<AnswerTypeItem>();

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
