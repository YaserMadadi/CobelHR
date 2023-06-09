
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
    public static class SchoolLevel_Action
    {
		
        public static async Task<DataResult<SchoolLevel>> SaveAttached(this SchoolLevel schoolLevel, UserCredit userCredit)
        {
            var permissionType = schoolLevel.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(schoolLevel.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<SchoolLevel>(-1, "You don't have Save Permission for ''SchoolLevel''", schoolLevel);

            return await schoolLevel.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<SchoolLevel>> SaveAttached(this SchoolLevel schoolLevel, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ISchoolLevelService schoolLevelService = new SchoolLevelService();

            var result = await schoolLevelService.Save(schoolLevel, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<SchoolLevel>(schoolLevel);

            Result childResult = null;

            if(schoolLevel.ListOfSchoolHistory.CheckList())
            {
                schoolLevel.ListOfSchoolHistory.ForEach(i => i.SchoolLevel.Id = result.Id);

                childResult = await schoolLevel.ListOfSchoolHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<SchoolLevel>(schoolLevel);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<SchoolLevel>(schoolLevel);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<SchoolLevel>> SaveCollection(this List<SchoolLevel> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<SchoolLevel> result = new SuccessfulDataResult<SchoolLevel>();

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
