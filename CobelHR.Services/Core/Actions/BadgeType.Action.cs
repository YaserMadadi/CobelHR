
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
    public static class BadgeType_Action
    {
		
        public static async Task<DataResult<BadgeType>> SaveAttached(this BadgeType badgeType, UserCredit userCredit)
        {
            var permissionType = badgeType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(badgeType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<BadgeType>(-1, "You don't have Save Permission for ''BadgeType''", badgeType);

            return await badgeType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<BadgeType>> SaveAttached(this BadgeType badgeType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IBadgeTypeService badgeTypeService = new BadgeTypeService();

            var result = await badgeTypeService.Save(badgeType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<BadgeType>(badgeType);

            Result childResult = null;

            if(badgeType.ListOfBadge.CheckList())
            {
                badgeType.ListOfBadge.ForEach(i => i.BadgeType.Id = result.Id);

                childResult = await badgeType.ListOfBadge.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<BadgeType>(badgeType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<BadgeType>(badgeType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<BadgeType>> SaveCollection(this List<BadgeType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<BadgeType> result = new SuccessfulDataResult<BadgeType>();

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
