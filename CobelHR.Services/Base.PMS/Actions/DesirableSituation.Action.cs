
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
    public static class DesirableSituation_Action
    {
		
        public static async Task<DataResult<DesirableSituation>> SaveAttached(this DesirableSituation desirableSituation, UserCredit userCredit)
        {
            var permissionType = desirableSituation.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(desirableSituation.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DesirableSituation>(-1, "You don't have Save Permission for ''DesirableSituation''", desirableSituation);

            return await desirableSituation.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DesirableSituation>> SaveAttached(this DesirableSituation desirableSituation, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDesirableSituationService desirableSituationService = new DesirableSituationService();

            var result = await desirableSituationService.Save(desirableSituation, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DesirableSituation>(desirableSituation);

            Result childResult = null;

            if(desirableSituation.ListOfIndividualDevelopmentPlan.CheckList())
            {
                desirableSituation.ListOfIndividualDevelopmentPlan.ForEach(i => i.DesirableSituation.Id = result.Id);

                childResult = await desirableSituation.ListOfIndividualDevelopmentPlan.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<DesirableSituation>(desirableSituation);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<DesirableSituation>(desirableSituation);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DesirableSituation>> SaveCollection(this List<DesirableSituation> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DesirableSituation> result = new SuccessfulDataResult<DesirableSituation>();

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
