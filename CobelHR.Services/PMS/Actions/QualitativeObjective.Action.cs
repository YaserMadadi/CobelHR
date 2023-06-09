
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
    public static class QualitativeObjective_Action
    {
		
        public static async Task<DataResult<QualitativeObjective>> SaveAttached(this QualitativeObjective qualitativeObjective, UserCredit userCredit)
        {
            var permissionType = qualitativeObjective.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(qualitativeObjective.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<QualitativeObjective>(-1, "You don't have Save Permission for ''QualitativeObjective''", qualitativeObjective);

            return await qualitativeObjective.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<QualitativeObjective>> SaveAttached(this QualitativeObjective qualitativeObjective, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IQualitativeObjectiveService qualitativeObjectiveService = new QualitativeObjectiveService();

            var result = await qualitativeObjectiveService.Save(qualitativeObjective, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<QualitativeObjective>(qualitativeObjective);

            Result childResult = null;

            if(qualitativeObjective.ListOfQualitativeKPI.CheckList())
            {
                qualitativeObjective.ListOfQualitativeKPI.ForEach(i => i.QualitativeObjective.Id = result.Id);

                childResult = await qualitativeObjective.ListOfQualitativeKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<QualitativeObjective>(qualitativeObjective);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<QualitativeObjective>(qualitativeObjective);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<QualitativeObjective>> SaveCollection(this List<QualitativeObjective> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<QualitativeObjective> result = new SuccessfulDataResult<QualitativeObjective>();

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
