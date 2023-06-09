using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Actions;
using CobelHR.Services.Core.Abstract;

namespace CobelHR.Services.Core
{
    public class MenuItemTypeService : Service<MenuItemType>, IMenuItemTypeService
    {
        public MenuItemTypeService() : base()
        {
        }

        public override async Task<DataResult<MenuItemType>> SaveAttached(MenuItemType menuItemType, UserCredit userCredit)
        {
            return await menuItemType.SaveAttached(userCredit);
        }

        public DataResult<List<MenuItem>> CollectionOfMenuItem(int menuItemType_Id, MenuItem menuItem, UserCredit userCredit)
        {
            var procedureName = "[Core].[MenuItemType.CollectionOfMenuItem]";

            return this.CollectionOf<MenuItem>(procedureName,
                                                    new SqlParameter("@Id",menuItemType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", menuItem.ToJson()));
        }
    }
}