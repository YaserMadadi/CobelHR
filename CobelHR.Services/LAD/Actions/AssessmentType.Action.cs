
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
    public static class AssessmentType_Action
    {
		
        public static async Task<DataResult<AssessmentType>> SaveAttached(this AssessmentType assessmentType, UserCredit userCredit)
        {
            var permissionType = assessmentType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessmentType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AssessmentType>(-1, "You don't have Save Permission for ''AssessmentType''", assessmentType);

            return await assessmentType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AssessmentType>> SaveAttached(this AssessmentType assessmentType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessmentTypeService assessmentTypeService = new AssessmentTypeService();

            var result = await assessmentTypeService.Save(assessmentType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AssessmentType>(assessmentType);

            Result childResult = null;

            if(assessmentType.ListOfAssessment.CheckList())
            {
                assessmentType.ListOfAssessment.ForEach(i => i.AssessmentType.Id = result.Id);

                childResult = await assessmentType.ListOfAssessment.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AssessmentType>(assessmentType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<AssessmentType>(assessmentType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AssessmentType>> SaveCollection(this List<AssessmentType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AssessmentType> result = new SuccessfulDataResult<AssessmentType>();

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
