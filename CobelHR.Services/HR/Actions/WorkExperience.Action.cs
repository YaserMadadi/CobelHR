
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class WorkExperience_Action
    {
		
        public static async Task<DataResult<WorkExperience>> SaveAttached(this WorkExperience workExperience, UserCredit userCredit)
        {
            var permissionType = workExperience.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(workExperience.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<WorkExperience>(-1, "You don't have Save Permission for ''WorkExperience''", workExperience);

            return await workExperience.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<WorkExperience>> SaveAttached(this WorkExperience workExperience, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IWorkExperienceService workExperienceService = new WorkExperienceService();

            var result = await workExperienceService.Save(workExperience, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<WorkExperience>(workExperience);

            

            if (depth > 0)

                return new SuccessfulDataResult<WorkExperience>(workExperience);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<WorkExperience>> SaveCollection(this List<WorkExperience> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<WorkExperience> result = new SuccessfulDataResult<WorkExperience>();

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
