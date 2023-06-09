
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
    public static class University_Action
    {
		
        public static async Task<DataResult<University>> SaveAttached(this University university, UserCredit userCredit)
        {
            var permissionType = university.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(university.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<University>(-1, "You don't have Save Permission for ''University''", university);

            return await university.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<University>> SaveAttached(this University university, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUniversityService universityService = new UniversityService();

            var result = await universityService.Save(university, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<University>(university);

            Result childResult = null;

            if(university.ListOfUniversityHistory.CheckList())
            {
                university.ListOfUniversityHistory.ForEach(i => i.University.Id = result.Id);

                childResult = await university.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<University>(university);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<University>(university);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<University>> SaveCollection(this List<University> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<University> result = new SuccessfulDataResult<University>();

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
