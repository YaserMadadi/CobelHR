
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
    public static class AppraisalApproverConfig_Action
    {
		
        public static async Task<DataResult<AppraisalApproverConfig>> SaveAttached(this AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit)
        {
            var permissionType = appraisalApproverConfig.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraisalApproverConfig.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AppraisalApproverConfig>(-1, "You don't have Save Permission for ''AppraisalApproverConfig''", appraisalApproverConfig);

            return await appraisalApproverConfig.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AppraisalApproverConfig>> SaveAttached(this AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraisalApproverConfigService appraisalApproverConfigService = new AppraisalApproverConfigService();

            var result = await appraisalApproverConfigService.Save(appraisalApproverConfig, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AppraisalApproverConfig>(appraisalApproverConfig);

            

            if (depth > 0)

                return new SuccessfulDataResult<AppraisalApproverConfig>(appraisalApproverConfig);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AppraisalApproverConfig>> SaveCollection(this List<AppraisalApproverConfig> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AppraisalApproverConfig> result = new SuccessfulDataResult<AppraisalApproverConfig>();

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
