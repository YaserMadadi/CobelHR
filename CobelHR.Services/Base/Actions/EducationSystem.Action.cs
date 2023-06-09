
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class EducationSystem_Action
    {
		
        public static async Task<DataResult<EducationSystem>> SaveAttached(this EducationSystem educationSystem, UserCredit userCredit)
        {
            var permissionType = educationSystem.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(educationSystem.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<EducationSystem>(-1, "You don't have Save Permission for ''EducationSystem''", educationSystem);

            return await educationSystem.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<EducationSystem>> SaveAttached(this EducationSystem educationSystem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEducationSystemService educationSystemService = new EducationSystemService();

            var result = await educationSystemService.Save(educationSystem, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<EducationSystem>(educationSystem);

            Result childResult = null;

            if(educationSystem.ListOfUniversityHistory.CheckList())
            {
                educationSystem.ListOfUniversityHistory.ForEach(i => i.EducationSystem.Id = result.Id);

                childResult = await educationSystem.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<EducationSystem>(educationSystem);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<EducationSystem>(educationSystem);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<EducationSystem>> SaveCollection(this List<EducationSystem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<EducationSystem> result = new SuccessfulDataResult<EducationSystem>();

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
