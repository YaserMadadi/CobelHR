
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
    public static class AnswerType_Action
    {
		
        public static async Task<DataResult<AnswerType>> SaveAttached(this AnswerType answerType, UserCredit userCredit)
        {
            var permissionType = answerType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(answerType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AnswerType>(-1, "You don't have Save Permission for ''AnswerType''", answerType);

            return await answerType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AnswerType>> SaveAttached(this AnswerType answerType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAnswerTypeService answerTypeService = new AnswerTypeService();

            var result = await answerTypeService.Save(answerType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AnswerType>(answerType);

            Result childResult = null;

            if(answerType.ListOfAnswerTypeItem.CheckList())
            {
                answerType.ListOfAnswerTypeItem.ForEach(i => i.AnswerType.Id = result.Id);

                childResult = await answerType.ListOfAnswerTypeItem.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AnswerType>(answerType);
                }
            }

            if(answerType.ListOfQuestionaryItem.CheckList())
            {
                answerType.ListOfQuestionaryItem.ForEach(i => i.AnswerType.Id = result.Id);

                childResult = await answerType.ListOfQuestionaryItem.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AnswerType>(answerType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<AnswerType>(answerType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AnswerType>> SaveCollection(this List<AnswerType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AnswerType> result = new SuccessfulDataResult<AnswerType>();

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
