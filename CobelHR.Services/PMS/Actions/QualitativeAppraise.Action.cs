
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
    public static class QualitativeAppraise_Action
    {
		
        public static async Task<DataResult<QualitativeAppraise>> SaveAttached(this QualitativeAppraise qualitativeAppraise, UserCredit userCredit)
        {
            var permissionType = qualitativeAppraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(qualitativeAppraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QualitativeAppraise>(-1, "You don't have Save Permission for ''QualitativeAppraise''", qualitativeAppraise);

            return await qualitativeAppraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QualitativeAppraise>> SaveAttached(this QualitativeAppraise qualitativeAppraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQualitativeAppraiseService qualitativeAppraiseService = new QualitativeAppraiseService();

            var result = await qualitativeAppraiseService.Save(qualitativeAppraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QualitativeAppraise>(qualitativeAppraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<QualitativeAppraise>(qualitativeAppraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QualitativeAppraise>> SaveCollection(this List<QualitativeAppraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QualitativeAppraise> result = new SuccessfulDataResult<QualitativeAppraise>();

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
