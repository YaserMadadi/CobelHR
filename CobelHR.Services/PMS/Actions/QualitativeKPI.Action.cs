
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
    public static class QualitativeKPI_Action
    {
		
        public static async Task<DataResult<QualitativeKPI>> SaveAttached(this QualitativeKPI qualitativeKPI, UserCredit userCredit)
        {
            var permissionType = qualitativeKPI.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(qualitativeKPI.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QualitativeKPI>(-1, "You don't have Save Permission for ''QualitativeKPI''", qualitativeKPI);

            return await qualitativeKPI.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QualitativeKPI>> SaveAttached(this QualitativeKPI qualitativeKPI, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQualitativeKPIService qualitativeKPIService = new QualitativeKPIService();

            var result = await qualitativeKPIService.Save(qualitativeKPI, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QualitativeKPI>(qualitativeKPI);

            Result childResult = null;

            if(qualitativeKPI.ListOfQualitativeAppraise.CheckList())
            {
                qualitativeKPI.ListOfQualitativeAppraise.ForEach(i => i.QualitativeKPI.Id = result.Id);

                childResult = await qualitativeKPI.ListOfQualitativeAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<QualitativeKPI>(qualitativeKPI);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<QualitativeKPI>(qualitativeKPI);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QualitativeKPI>> SaveCollection(this List<QualitativeKPI> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QualitativeKPI> result = new SuccessfulDataResult<QualitativeKPI>();

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
