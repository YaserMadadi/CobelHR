
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Abstract;


namespace CobelHR.Services.PMS.Pharma.Actions
{
    public static class Appraise_Action
    {
		
        public static async Task<DataResult<Appraise>> SaveAttached(this Appraise appraise, UserCredit userCredit)
        {
            var permissionType = appraise.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraise.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Appraise>(-1, "You don't have Save Permission for ''Appraise''", appraise);

            return await appraise.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Appraise>> SaveAttached(this Appraise appraise, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraiseService appraiseService = new AppraiseService();

            var result = await appraiseService.Save(appraise, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Appraise>(appraise);

            

            if (depth > 0)

                return new SuccessfulDataResult<Appraise>(appraise);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Appraise>> SaveCollection(this List<Appraise> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Appraise> result = new SuccessfulDataResult<Appraise>();

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
