
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
    public static class RotationAssessment_Action
    {
		
        public static async Task<DataResult<RotationAssessment>> SaveAttached(this RotationAssessment rotationAssessment, UserCredit userCredit)
        {
            var permissionType = rotationAssessment.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(rotationAssessment.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<RotationAssessment>(-1, "You don't have Save Permission for ''RotationAssessment''", rotationAssessment);

            return await rotationAssessment.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<RotationAssessment>> SaveAttached(this RotationAssessment rotationAssessment, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IRotationAssessmentService rotationAssessmentService = new RotationAssessmentService();

            var result = await rotationAssessmentService.Save(rotationAssessment, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<RotationAssessment>(rotationAssessment);

            

            if (depth > 0)

                return new SuccessfulDataResult<RotationAssessment>(rotationAssessment);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<RotationAssessment>> SaveCollection(this List<RotationAssessment> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<RotationAssessment> result = new SuccessfulDataResult<RotationAssessment>();

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
