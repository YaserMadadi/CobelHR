
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
    public static class UniversityHistory_Action
    {
		
        public static async Task<DataResult<UniversityHistory>> SaveAttached(this UniversityHistory universityHistory, UserCredit userCredit)
        {
            var permissionType = universityHistory.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(universityHistory.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<UniversityHistory>(-1, "You don't have Save Permission for ''UniversityHistory''", universityHistory);

            return await universityHistory.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<UniversityHistory>> SaveAttached(this UniversityHistory universityHistory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUniversityHistoryService universityHistoryService = new UniversityHistoryService();

            var result = await universityHistoryService.Save(universityHistory, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<UniversityHistory>(universityHistory);

            Result childResult = null;

            if(universityHistory.ListOfUniversityTerminate.CheckList())
            {
                universityHistory.ListOfUniversityTerminate.ForEach(i => i.UniversityHistory.Id = result.Id);

                childResult = await universityHistory.ListOfUniversityTerminate.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<UniversityHistory>(universityHistory);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<UniversityHistory>(universityHistory);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<UniversityHistory>> SaveCollection(this List<UniversityHistory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<UniversityHistory> result = new SuccessfulDataResult<UniversityHistory>();

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
