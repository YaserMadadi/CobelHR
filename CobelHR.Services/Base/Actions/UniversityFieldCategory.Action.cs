
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


namespace CobelHR.Services.Base.Actions
{
    public static class UniversityFieldCategory_Action
    {
		
        public static async Task<DataResult<UniversityFieldCategory>> SaveAttached(this UniversityFieldCategory universityFieldCategory, UserCredit userCredit)
        {
            var permissionType = universityFieldCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(universityFieldCategory.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<UniversityFieldCategory>(-1, "You don't have Save Permission for ''UniversityFieldCategory''", universityFieldCategory);

            return await universityFieldCategory.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<UniversityFieldCategory>> SaveAttached(this UniversityFieldCategory universityFieldCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUniversityFieldCategoryService universityFieldCategoryService = new UniversityFieldCategoryService();

            var result = await universityFieldCategoryService.Save(universityFieldCategory, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<UniversityFieldCategory>(universityFieldCategory);

            Result childResult = null;

            if(universityFieldCategory.ListOfFieldOfStudy.CheckList())
            {
                universityFieldCategory.ListOfFieldOfStudy.ForEach(i => i.UniversityFieldCategory.Id = result.Id);

                childResult = await universityFieldCategory.ListOfFieldOfStudy.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<UniversityFieldCategory>(universityFieldCategory);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<UniversityFieldCategory>(universityFieldCategory);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<UniversityFieldCategory>> SaveCollection(this List<UniversityFieldCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<UniversityFieldCategory> result = new SuccessfulDataResult<UniversityFieldCategory>();

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
