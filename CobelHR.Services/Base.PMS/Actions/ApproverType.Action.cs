
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
    public static class ApproverType_Action
    {
		
        public static async Task<DataResult<ApproverType>> SaveAttached(this ApproverType approverType, UserCredit userCredit)
        {
            var permissionType = approverType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(approverType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ApproverType>(-1, "You don't have Save Permission for ''ApproverType''", approverType);

            return await approverType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ApproverType>> SaveAttached(this ApproverType approverType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IApproverTypeService approverTypeService = new ApproverTypeService();

            var result = await approverTypeService.Save(approverType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ApproverType>(approverType);

            Result childResult = null;

            if(approverType.ListOfAppraisalApproverConfig.CheckList())
            {
                approverType.ListOfAppraisalApproverConfig.ForEach(i => i.ApproverType.Id = result.Id);

                childResult = await approverType.ListOfAppraisalApproverConfig.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ApproverType>(approverType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ApproverType>(approverType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ApproverType>> SaveCollection(this List<ApproverType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ApproverType> result = new SuccessfulDataResult<ApproverType>();

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
