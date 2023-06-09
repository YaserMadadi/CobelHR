
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
    public static class Conclusion_Action
    {
		
        public static async Task<DataResult<Conclusion>> SaveAttached(this Conclusion conclusion, UserCredit userCredit)
        {
            var permissionType = conclusion.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(conclusion.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Conclusion>(-1, "You don't have Save Permission for ''Conclusion''", conclusion);

            return await conclusion.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Conclusion>> SaveAttached(this Conclusion conclusion, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConclusionService conclusionService = new ConclusionService();

            var result = await conclusionService.Save(conclusion, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Conclusion>(conclusion);

            

            if (depth > 0)

                return new SuccessfulDataResult<Conclusion>(conclusion);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Conclusion>> SaveCollection(this List<Conclusion> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Conclusion> result = new SuccessfulDataResult<Conclusion>();

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
