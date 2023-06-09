
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
    public static class IndividualDevelopmentPlan_Action
    {

        public static async Task<DataResult<IndividualDevelopmentPlan>> SaveAttached(this IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            var permissionType = individualDevelopmentPlan.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(individualDevelopmentPlan.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<IndividualDevelopmentPlan>(-1, "You don't have Save Permission for ''IndividualDevelopmentPlan''", individualDevelopmentPlan);

            return await individualDevelopmentPlan.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<IndividualDevelopmentPlan>> SaveAttached(this IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IIndividualDevelopmentPlanService individualDevelopmentPlanService = new IndividualDevelopmentPlanService();

            var result = await individualDevelopmentPlanService.Save(individualDevelopmentPlan, userCredit, transaction);

            if (result.Id <= 0)

                return result;

            //Result childResult = null;

            if (individualDevelopmentPlan.ListOfDevelopmentPlanCompetency.CheckList())
            {
                individualDevelopmentPlan.ListOfDevelopmentPlanCompetency.ForEach(i => i.IndividualDevelopmentPlan.Id = result.Id);

                var childResult = await individualDevelopmentPlan.ListOfDevelopmentPlanCompetency.SaveCollection(userCredit, transaction, depth + 1);

                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<IndividualDevelopmentPlan>(result.Data);
                }
            }

            if (depth > 0)

                return new SuccessfulDataResult<IndividualDevelopmentPlan>(individualDevelopmentPlan);

            transaction.Commit();

            result = await individualDevelopmentPlanService.RetrieveById(result.Id, IndividualDevelopmentPlan.Informer, userCredit);

            return result;
        }



        public static async Task<DataResult<IndividualDevelopmentPlan>> SaveCollection(this List<IndividualDevelopmentPlan> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<IndividualDevelopmentPlan> result = new SuccessfulDataResult<IndividualDevelopmentPlan>();

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
