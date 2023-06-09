
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
    public static class ExpectedLevel_Action
    {
		
        public static async Task<DataResult<ExpectedLevel>> SaveAttached(this ExpectedLevel expectedLevel, UserCredit userCredit)
        {
            var permissionType = expectedLevel.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(expectedLevel.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ExpectedLevel>(-1, "You don't have Save Permission for ''ExpectedLevel''", expectedLevel);

            return await expectedLevel.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ExpectedLevel>> SaveAttached(this ExpectedLevel expectedLevel, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IExpectedLevelService expectedLevelService = new ExpectedLevelService();

            var result = await expectedLevelService.Save(expectedLevel, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ExpectedLevel>(expectedLevel);

            Result childResult = null;

            if(expectedLevel.ListOfBehavioralObjective.CheckList())
            {
                expectedLevel.ListOfBehavioralObjective.ForEach(i => i.ExpectedLevel.Id = result.Id);

                childResult = await expectedLevel.ListOfBehavioralObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ExpectedLevel>(expectedLevel);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ExpectedLevel>(expectedLevel);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ExpectedLevel>> SaveCollection(this List<ExpectedLevel> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ExpectedLevel> result = new SuccessfulDataResult<ExpectedLevel>();

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
