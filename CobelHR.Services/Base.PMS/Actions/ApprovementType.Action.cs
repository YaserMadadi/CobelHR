
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class ApprovementType_Action
    {
		
        public static async Task<DataResult<ApprovementType>> SaveAttached(this ApprovementType approvementType, UserCredit userCredit)
        {
            var permissionType = approvementType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(approvementType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ApprovementType>(-1, "You don't have Save Permission for ''ApprovementType''", approvementType);

            return await approvementType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ApprovementType>> SaveAttached(this ApprovementType approvementType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IApprovementTypeService approvementTypeService = new ApprovementTypeService();

            var result = await approvementTypeService.Save(approvementType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ApprovementType>(approvementType);

            Result childResult = null;

            if(approvementType.ListOfVisionApproved.CheckList())
            {
                approvementType.ListOfVisionApproved.ForEach(i => i.ApprovementType.Id = result.Id);

                childResult = await approvementType.ListOfVisionApproved.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ApprovementType>(approvementType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ApprovementType>(approvementType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ApprovementType>> SaveCollection(this List<ApprovementType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ApprovementType> result = new SuccessfulDataResult<ApprovementType>();

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
