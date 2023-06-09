
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
    public static class UniversityTerminate_Action
    {
		
        public static async Task<DataResult<UniversityTerminate>> SaveAttached(this UniversityTerminate universityTerminate, UserCredit userCredit)
        {
            var permissionType = universityTerminate.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(universityTerminate.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<UniversityTerminate>(-1, "You don't have Save Permission for ''UniversityTerminate''", universityTerminate);

            return await universityTerminate.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<UniversityTerminate>> SaveAttached(this UniversityTerminate universityTerminate, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUniversityTerminateService universityTerminateService = new UniversityTerminateService();

            var result = await universityTerminateService.Save(universityTerminate, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<UniversityTerminate>(universityTerminate);

            

            if (depth > 0)

                return new SuccessfulDataResult<UniversityTerminate>(universityTerminate);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<UniversityTerminate>> SaveCollection(this List<UniversityTerminate> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<UniversityTerminate> result = new SuccessfulDataResult<UniversityTerminate>();

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
