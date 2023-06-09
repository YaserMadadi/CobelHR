
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;


namespace CobelHR.Services.Base.Actions
{
    public static class Quarter_Action
    {
		
        public static async Task<DataResult<Quarter>> SaveAttached(this Quarter quarter, UserCredit userCredit)
        {
            var permissionType = quarter.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(quarter.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Quarter>(-1, "You don't have Save Permission for ''Quarter''", quarter);

            return await quarter.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Quarter>> SaveAttached(this Quarter quarter, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQuarterService quarterService = new QuarterService();

            var result = await quarterService.Save(quarter, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Quarter>(quarter);

            Result childResult = null;

            if(quarter.ListOfYearQuarter.CheckList())
            {
                quarter.ListOfYearQuarter.ForEach(i => i.Quarter.Id = result.Id);

                childResult = await quarter.ListOfYearQuarter.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Quarter>(quarter);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Quarter>(quarter);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Quarter>> SaveCollection(this List<Quarter> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Quarter> result = new SuccessfulDataResult<Quarter>();

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
