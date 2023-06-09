
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
    public static class FunctionalObjectiveComment_Action
    {
		
        public static async Task<DataResult<FunctionalObjectiveComment>> SaveAttached(this FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit)
        {
            var permissionType = functionalObjectiveComment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(functionalObjectiveComment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FunctionalObjectiveComment>(-1, "You don't have Save Permission for ''FunctionalObjectiveComment''", functionalObjectiveComment);

            return await functionalObjectiveComment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FunctionalObjectiveComment>> SaveAttached(this FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFunctionalObjectiveCommentService functionalObjectiveCommentService = new FunctionalObjectiveCommentService();

            var result = await functionalObjectiveCommentService.Save(functionalObjectiveComment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FunctionalObjectiveComment>(functionalObjectiveComment);

            

            if (depth > 0)

                return new SuccessfulDataResult<FunctionalObjectiveComment>(functionalObjectiveComment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FunctionalObjectiveComment>> SaveCollection(this List<FunctionalObjectiveComment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FunctionalObjectiveComment> result = new SuccessfulDataResult<FunctionalObjectiveComment>();

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
