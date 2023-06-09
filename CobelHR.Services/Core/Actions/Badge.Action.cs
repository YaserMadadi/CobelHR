
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Abstract;


namespace CobelHR.Services.Core.Actions
{
    public static class Badge_Action
    {
		
        public static async Task<DataResult<Badge>> SaveAttached(this Badge badge, UserCredit userCredit)
        {
            var permissionType = badge.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(badge.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Badge>(-1, "You don't have Save Permission for ''Badge''", badge);

            return await badge.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Badge>> SaveAttached(this Badge badge, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IBadgeService badgeService = new BadgeService();

            var result = await badgeService.Save(badge, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Badge>(badge);

            

            if (depth > 0)

                return new SuccessfulDataResult<Badge>(badge);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Badge>> SaveCollection(this List<Badge> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Badge> result = new SuccessfulDataResult<Badge>();

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
