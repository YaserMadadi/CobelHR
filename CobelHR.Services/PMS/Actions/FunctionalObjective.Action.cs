
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
    public static class FunctionalObjective_Action
    {
		
        public static async Task<DataResult<FunctionalObjective>> SaveAttached(this FunctionalObjective functionalObjective, UserCredit userCredit)
        {
            var permissionType = functionalObjective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(functionalObjective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FunctionalObjective>(-1, "You don't have Save Permission for ''FunctionalObjective''", functionalObjective);

            return await functionalObjective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FunctionalObjective>> SaveAttached(this FunctionalObjective functionalObjective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFunctionalObjectiveService functionalObjectiveService = new FunctionalObjectiveService();

            var result = await functionalObjectiveService.Save(functionalObjective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FunctionalObjective>(functionalObjective);

            Result childResult = null;

            if(functionalObjective.ListOfFunctionalKPI.CheckList())
            {
                functionalObjective.ListOfFunctionalKPI.ForEach(i => i.FunctionalObjective.Id = result.Id);

                childResult = await functionalObjective.ListOfFunctionalKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FunctionalObjective>(functionalObjective);
                }
            }

            if(functionalObjective.ListOfChildFunctionalObjective.CheckList())
            {
                functionalObjective.ListOfChildFunctionalObjective.ForEach(i => i.ParentalFunctionalObjective.Id = result.Id);

                childResult = await functionalObjective.ListOfChildFunctionalObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FunctionalObjective>(functionalObjective);
                }
            }

            if(functionalObjective.ListOfFunctionalObjectiveComment.CheckList())
            {
                functionalObjective.ListOfFunctionalObjectiveComment.ForEach(i => i.FunctionalObjective.Id = result.Id);

                childResult = await functionalObjective.ListOfFunctionalObjectiveComment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FunctionalObjective>(functionalObjective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<FunctionalObjective>(functionalObjective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FunctionalObjective>> SaveCollection(this List<FunctionalObjective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FunctionalObjective> result = new SuccessfulDataResult<FunctionalObjective>();

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
