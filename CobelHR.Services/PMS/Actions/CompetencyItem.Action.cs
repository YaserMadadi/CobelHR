
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
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.PMS.Actions
{
    public static class CompetencyItem_Action
    {
		
        public static async Task<DataResult<CompetencyItem>> SaveAttached(this CompetencyItem competencyItem, UserCredit userCredit)
        {
            var permissionType = competencyItem.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(competencyItem.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CompetencyItem>(-1, "You don't have Save Permission for ''CompetencyItem''", competencyItem);

            return await competencyItem.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CompetencyItem>> SaveAttached(this CompetencyItem competencyItem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICompetencyItemService competencyItemService = new CompetencyItemService();

            var result = await competencyItemService.Save(competencyItem, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CompetencyItem>(competencyItem);

            Result childResult = null;

            if(competencyItem.ListOfAssessmentScore.CheckList())
            {
                competencyItem.ListOfAssessmentScore.ForEach(i => i.CompetencyItem.Id = result.Id);

                childResult = await competencyItem.ListOfAssessmentScore.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CompetencyItem>(competencyItem);
                }
            }

            if(competencyItem.ListOfBehavioralObjective.CheckList())
            {
                competencyItem.ListOfBehavioralObjective.ForEach(i => i.CompetencyItem.Id = result.Id);

                childResult = await competencyItem.ListOfBehavioralObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CompetencyItem>(competencyItem);
                }
            }

            if(competencyItem.ListOfCompetencyItemKPI.CheckList())
            {
                competencyItem.ListOfCompetencyItemKPI.ForEach(i => i.CompetencyItem.Id = result.Id);

                childResult = await competencyItem.ListOfCompetencyItemKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CompetencyItem>(competencyItem);
                }
            }

            if(competencyItem.ListOfDevelopmentPlanCompetency.CheckList())
            {
                competencyItem.ListOfDevelopmentPlanCompetency.ForEach(i => i.CompetencyItem.Id = result.Id);

                childResult = await competencyItem.ListOfDevelopmentPlanCompetency.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CompetencyItem>(competencyItem);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CompetencyItem>(competencyItem);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CompetencyItem>> SaveCollection(this List<CompetencyItem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CompetencyItem> result = new SuccessfulDataResult<CompetencyItem>();

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
