
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
    public static class FunctionalKPI_Action
    {
		
        public static async Task<DataResult<FunctionalKPI>> SaveAttached(this FunctionalKPI functionalKPI, UserCredit userCredit)
        {
            var permissionType = functionalKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(functionalKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FunctionalKPI>(-1, "You don't have Save Permission for ''FunctionalKPI''", functionalKPI);

            return await functionalKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FunctionalKPI>> SaveAttached(this FunctionalKPI functionalKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFunctionalKPIService functionalKPIService = new FunctionalKPIService();

            var result = await functionalKPIService.Save(functionalKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FunctionalKPI>(functionalKPI);

            Result childResult = null;

            if(functionalKPI.ListOfFunctionalAppraise.CheckList())
            {
                functionalKPI.ListOfFunctionalAppraise.ForEach(i => i.FunctionalKPI.Id = result.Id);

                childResult = await functionalKPI.ListOfFunctionalAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FunctionalKPI>(functionalKPI);
                }
            }

            if(functionalKPI.ListOfFunctionalKPIComment.CheckList())
            {
                functionalKPI.ListOfFunctionalKPIComment.ForEach(i => i.FunctionalKPI.Id = result.Id);

                childResult = await functionalKPI.ListOfFunctionalKPIComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FunctionalKPI>(functionalKPI);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<FunctionalKPI>(functionalKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FunctionalKPI>> SaveCollection(this List<FunctionalKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FunctionalKPI> result = new SuccessfulDataResult<FunctionalKPI>();

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
