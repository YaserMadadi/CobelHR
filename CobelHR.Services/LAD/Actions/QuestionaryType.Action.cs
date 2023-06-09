
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
    public static class QuestionaryType_Action
    {
		
        public static async Task<DataResult<QuestionaryType>> SaveAttached(this QuestionaryType questionaryType, UserCredit userCredit)
        {
            var permissionType = questionaryType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(questionaryType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QuestionaryType>(-1, "You don't have Save Permission for ''QuestionaryType''", questionaryType);

            return await questionaryType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QuestionaryType>> SaveAttached(this QuestionaryType questionaryType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQuestionaryTypeService questionaryTypeService = new QuestionaryTypeService();

            var result = await questionaryTypeService.Save(questionaryType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QuestionaryType>(questionaryType);

            Result childResult = null;

            if(questionaryType.ListOfCoachingQuestionary.CheckList())
            {
                questionaryType.ListOfCoachingQuestionary.ForEach(i => i.QuestionaryType.Id = result.Id);

                childResult = await questionaryType.ListOfCoachingQuestionary.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<QuestionaryType>(questionaryType);
                }
            }

            if(questionaryType.ListOfQuestionaryItem.CheckList())
            {
                questionaryType.ListOfQuestionaryItem.ForEach(i => i.QuestionaryType.Id = result.Id);

                childResult = await questionaryType.ListOfQuestionaryItem.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<QuestionaryType>(questionaryType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<QuestionaryType>(questionaryType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QuestionaryType>> SaveCollection(this List<QuestionaryType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QuestionaryType> result = new SuccessfulDataResult<QuestionaryType>();

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
