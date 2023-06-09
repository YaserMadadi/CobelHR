
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
    public static class CurrentSituation_Action
    {
		
        public static async Task<DataResult<CurrentSituation>> SaveAttached(this CurrentSituation currentSituation, UserCredit userCredit)
        {
            var permissionType = currentSituation.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(currentSituation.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CurrentSituation>(-1, "You don't have Save Permission for ''CurrentSituation''", currentSituation);

            return await currentSituation.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CurrentSituation>> SaveAttached(this CurrentSituation currentSituation, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICurrentSituationService currentSituationService = new CurrentSituationService();

            var result = await currentSituationService.Save(currentSituation, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CurrentSituation>(currentSituation);

            Result childResult = null;

            if(currentSituation.ListOfIndividualDevelopmentPlan.CheckList())
            {
                currentSituation.ListOfIndividualDevelopmentPlan.ForEach(i => i.CurrentSituation.Id = result.Id);

                childResult = await currentSituation.ListOfIndividualDevelopmentPlan.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CurrentSituation>(currentSituation);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CurrentSituation>(currentSituation);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CurrentSituation>> SaveCollection(this List<CurrentSituation> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CurrentSituation> result = new SuccessfulDataResult<CurrentSituation>();

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
