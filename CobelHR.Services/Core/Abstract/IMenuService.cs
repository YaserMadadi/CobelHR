using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IMenuService : IService<Menu>
    {
        DataResult<List<MenuItem>> CollectionOfMenuItem(int menu_Id, MenuItem menuItem, UserCredit userCredit);
    }
}
