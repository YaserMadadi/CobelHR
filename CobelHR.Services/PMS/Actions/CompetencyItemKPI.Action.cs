
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
    public static class CompetencyItemKPI_Action
    {
		
        public static async Task<DataResult<CompetencyItemKPI>> SaveAttached(this CompetencyItemKPI competencyItemKPI, UserCredit userCredit)
        {
            var permissionType = competencyItemKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(competencyItemKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CompetencyItemKPI>(-1, "You don't have Save Permission for ''CompetencyItemKPI''", competencyItemKPI);

            return await competencyItemKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CompetencyItemKPI>> SaveAttached(this CompetencyItemKPI competencyItemKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICompetencyItemKPIService competencyItemKPIService = new CompetencyItemKPIService();

            var result = await competencyItemKPIService.Save(competencyItemKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CompetencyItemKPI>(competencyItemKPI);

            Result childResult = null;

            if(competencyItemKPI.ListOfBehavioralKPI.CheckList())
            {
                competencyItemKPI.ListOfBehavioralKPI.ForEach(i => i.CompetencyItemKPI.Id = result.Id);

                childResult = await competencyItemKPI.ListOfBehavioralKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CompetencyItemKPI>(competencyItemKPI);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CompetencyItemKPI>(competencyItemKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CompetencyItemKPI>> SaveCollection(this List<CompetencyItemKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CompetencyItemKPI> result = new SuccessfulDataResult<CompetencyItemKPI>();

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
