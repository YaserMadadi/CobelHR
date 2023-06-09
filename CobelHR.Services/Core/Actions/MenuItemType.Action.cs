
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
    public static class MenuItemType_Action
    {
		
        public static async Task<DataResult<MenuItemType>> SaveAttached(this MenuItemType menuItemType, UserCredit userCredit)
        {
            var permissionType = menuItemType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(menuItemType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MenuItemType>(-1, "You don't have Save Permission for ''MenuItemType''", menuItemType);

            return await menuItemType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MenuItemType>> SaveAttached(this MenuItemType menuItemType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMenuItemTypeService menuItemTypeService = new MenuItemTypeService();

            var result = await menuItemTypeService.Save(menuItemType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MenuItemType>(menuItemType);

            Result childResult = null;

            if(menuItemType.ListOfMenuItem.CheckList())
            {
                menuItemType.ListOfMenuItem.ForEach(i => i.MenuItemType.Id = result.Id);

                childResult = await menuItemType.ListOfMenuItem.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MenuItemType>(menuItemType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<MenuItemType>(menuItemType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MenuItemType>> SaveCollection(this List<MenuItemType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MenuItemType> result = new SuccessfulDataResult<MenuItemType>();

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
