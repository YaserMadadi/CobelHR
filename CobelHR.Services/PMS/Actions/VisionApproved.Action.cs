
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
    public static class VisionApproved_Action
    {
		
        public static async Task<DataResult<VisionApproved>> SaveAttached(this VisionApproved visionApproved, UserCredit userCredit)
        {
            var permissionType = visionApproved.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(visionApproved.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<VisionApproved>(-1, "You don't have Save Permission for ''VisionApproved''", visionApproved);

            return await visionApproved.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<VisionApproved>> SaveAttached(this VisionApproved visionApproved, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IVisionApprovedService visionApprovedService = new VisionApprovedService();

            var result = await visionApprovedService.Save(visionApproved, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<VisionApproved>(visionApproved);

            

            if (depth > 0)

                return new SuccessfulDataResult<VisionApproved>(visionApproved);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<VisionApproved>> SaveCollection(this List<VisionApproved> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<VisionApproved> result = new SuccessfulDataResult<VisionApproved>();

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
