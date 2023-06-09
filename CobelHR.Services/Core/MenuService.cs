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
    public class MenuService : Service<Menu>, IMenuService
    {
        public MenuService() : base()
        {
        }

        public override async Task<DataResult<Menu>> SaveAttached(Menu menu, UserCredit userCredit)
        {
            return await menu.SaveAttached(userCredit);
        }

        public DataResult<List<MenuItem>> CollectionOfMenuItem(int menu_Id, MenuItem menuItem, UserCredit userCredit)
        {
            var procedureName = "[Core].[Menu.CollectionOfMenuItem]";

            return this.CollectionOf<MenuItem>(procedureName,
                                                    new SqlParameter("@Id",menu_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", menuItem.ToJson()));
        }
    }
}