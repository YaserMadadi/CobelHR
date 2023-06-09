
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Abstract;


namespace CobelHR.Services.PMS.Pharma.Actions
{
    public static class KPI_Action
    {
		
        public static async Task<DataResult<KPI>> SaveAttached(this KPI kpi, UserCredit userCredit)
        {
            var permissionType = kpi.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(kpi.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<KPI>(-1, "You don't have Save Permission for ''KPI''", kpi);

            return await kpi.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<KPI>> SaveAttached(this KPI kpi, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IKPIService kpiService = new KPIService();

            var result = await kpiService.Save(kpi, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<KPI>(kpi);

            Result childResult = null;

            if(kpi.ListOfAppraise.CheckList())
            {
                kpi.ListOfAppraise.ForEach(i => i.KPI.Id = result.Id);

                childResult = await kpi.ListOfAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<KPI>(kpi);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<KPI>(kpi);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<KPI>> SaveCollection(this List<KPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<KPI> result = new SuccessfulDataResult<KPI>();

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
