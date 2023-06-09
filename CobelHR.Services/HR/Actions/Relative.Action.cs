
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
    public static class Relative_Action
    {
		
        public static async Task<DataResult<Relative>> SaveAttached(this Relative relative, UserCredit userCredit)
        {
            var permissionType = relative.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(relative.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Relative>(-1, "You don't have Save Permission for ''Relative''", relative);

            return await relative.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Relative>> SaveAttached(this Relative relative, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IRelativeService relativeService = new RelativeService();

            var result = await relativeService.Save(relative, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Relative>(relative);

            

            if (depth > 0)

                return new SuccessfulDataResult<Relative>(relative);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Relative>> SaveCollection(this List<Relative> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Relative> result = new SuccessfulDataResult<Relative>();

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
