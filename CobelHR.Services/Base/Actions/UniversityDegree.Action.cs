
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
    public static class UniversityDegree_Action
    {
		
        public static async Task<DataResult<UniversityDegree>> SaveAttached(this UniversityDegree universityDegree, UserCredit userCredit)
        {
            var permissionType = universityDegree.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(universityDegree.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<UniversityDegree>(-1, "You don't have Save Permission for ''UniversityDegree''", universityDegree);

            return await universityDegree.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<UniversityDegree>> SaveAttached(this UniversityDegree universityDegree, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUniversityDegreeService universityDegreeService = new UniversityDegreeService();

            var result = await universityDegreeService.Save(universityDegree, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<UniversityDegree>(universityDegree);

            Result childResult = null;

            if(universityDegree.ListOfUniversityHistory.CheckList())
            {
                universityDegree.ListOfUniversityHistory.ForEach(i => i.UniversityDegree.Id = result.Id);

                childResult = await universityDegree.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<UniversityDegree>(universityDegree);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<UniversityDegree>(universityDegree);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<UniversityDegree>> SaveCollection(this List<UniversityDegree> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<UniversityDegree> result = new SuccessfulDataResult<UniversityDegree>();

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
