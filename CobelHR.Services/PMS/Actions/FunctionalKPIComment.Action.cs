
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
    public static class FunctionalKPIComment_Action
    {
		
        public static async Task<DataResult<FunctionalKPIComment>> SaveAttached(this FunctionalKPIComment functionalKPIComment, UserCredit userCredit)
        {
            var permissionType = functionalKPIComment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(functionalKPIComment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FunctionalKPIComment>(-1, "You don't have Save Permission for ''FunctionalKPIComment''", functionalKPIComment);

            return await functionalKPIComment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FunctionalKPIComment>> SaveAttached(this FunctionalKPIComment functionalKPIComment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFunctionalKPICommentService functionalKPICommentService = new FunctionalKPICommentService();

            var result = await functionalKPICommentService.Save(functionalKPIComment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FunctionalKPIComment>(functionalKPIComment);

            

            if (depth > 0)

                return new SuccessfulDataResult<FunctionalKPIComment>(functionalKPIComment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FunctionalKPIComment>> SaveCollection(this List<FunctionalKPIComment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FunctionalKPIComment> result = new SuccessfulDataResult<FunctionalKPIComment>();

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
