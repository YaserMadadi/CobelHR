using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IMenuItemTypeService : IService<MenuItemType>
    {
        DataResult<List<MenuItem>> CollectionOfMenuItem(int menuItemType_Id, MenuItem menuItem, UserCredit userCredit);
    }
}
