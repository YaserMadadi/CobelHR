
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
    public static class QuestionaryItem_Action
    {
		
        public static async Task<DataResult<QuestionaryItem>> SaveAttached(this QuestionaryItem questionaryItem, UserCredit userCredit)
        {
            var permissionType = questionaryItem.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(questionaryItem.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QuestionaryItem>(-1, "You don't have Save Permission for ''QuestionaryItem''", questionaryItem);

            return await questionaryItem.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QuestionaryItem>> SaveAttached(this QuestionaryItem questionaryItem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQuestionaryItemService questionaryItemService = new QuestionaryItemService();

            var result = await questionaryItemService.Save(questionaryItem, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QuestionaryItem>(questionaryItem);

            Result childResult = null;

            if(questionaryItem.ListOfCoachingQuestionaryAnswered.CheckList())
            {
                questionaryItem.ListOfCoachingQuestionaryAnswered.ForEach(i => i.QuestionaryItem.Id = result.Id);

                childResult = await questionaryItem.ListOfCoachingQuestionaryAnswered.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<QuestionaryItem>(questionaryItem);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<QuestionaryItem>(questionaryItem);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QuestionaryItem>> SaveCollection(this List<QuestionaryItem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QuestionaryItem> result = new SuccessfulDataResult<QuestionaryItem>();

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
