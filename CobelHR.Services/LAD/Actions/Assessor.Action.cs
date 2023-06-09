
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Abstract;


namespace CobelHR.Services.LAD.Actions
{
    public static class Assessor_Action
    {
		
        public static async Task<DataResult<Assessor>> SaveAttached(this Assessor assessor, UserCredit userCredit)
        {
            var permissionType = assessor.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessor.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Assessor>(-1, "You don't have Save Permission for ''Assessor''", assessor);

            return await assessor.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Assessor>> SaveAttached(this Assessor assessor, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessorService assessorService = new AssessorService();

            var result = await assessorService.Save(assessor, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Assessor>(assessor);

            Result childResult = null;

            if(assessor.ListOfAssessment.CheckList())
            {
                assessor.ListOfAssessment.ForEach(i => i.Assessor.Id = result.Id);

                childResult = await assessor.ListOfAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessor>(assessor);
                }
            }

            if(assessor.ListOfAssessorConnectionLine.CheckList())
            {
                assessor.ListOfAssessorConnectionLine.ForEach(i => i.Assessor.Id = result.Id);

                childResult = await assessor.ListOfAssessorConnectionLine.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Assessor>(assessor);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Assessor>(assessor);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Assessor>> SaveCollection(this List<Assessor> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Assessor> result = new SuccessfulDataResult<Assessor>();

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
