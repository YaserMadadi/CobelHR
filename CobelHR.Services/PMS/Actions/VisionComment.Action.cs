
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
    public static class VisionComment_Action
    {
		
        public static async Task<DataResult<VisionComment>> SaveAttached(this VisionComment visionComment, UserCredit userCredit)
        {
            var permissionType = visionComment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(visionComment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<VisionComment>(-1, "You don't have Save Permission for ''VisionComment''", visionComment);

            return await visionComment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<VisionComment>> SaveAttached(this VisionComment visionComment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IVisionCommentService visionCommentService = new VisionCommentService();

            var result = await visionCommentService.Save(visionComment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<VisionComment>(visionComment);

            

            if (depth > 0)

                return new SuccessfulDataResult<VisionComment>(visionComment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<VisionComment>> SaveCollection(this List<VisionComment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<VisionComment> result = new SuccessfulDataResult<VisionComment>();

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
