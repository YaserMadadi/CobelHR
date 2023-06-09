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
    public class MenuItemService : Service<MenuItem>, IMenuItemService
    {
        public MenuItemService() : base()
        {
        }

        public override async Task<DataResult<MenuItem>> SaveAttached(MenuItem menuItem, UserCredit userCredit)
        {
            return await menuItem.SaveAttached(userCredit);
        }

        public DataResult<List<Badge>> CollectionOfBadge(int menuItem_Id, Badge badge, UserCredit userCredit)
        {
            var procedureName = "[Core].[MenuItem.CollectionOfBadge]";

            return this.CollectionOf<Badge>(procedureName,
                                                    new SqlParameter("@Id",menuItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", badge.ToJson()));
        }

		//public DataResult<List<RoleMenuItem>> CollectionOfRoleMenuItem(int menuItem_Id, RoleMenuItem roleMenuItem, UserCredit userCredit)
  //      {
  //          var procedureName = "[Core].[MenuItem.CollectionOfRoleMenuItem]";

  //          return this.CollectionOf<RoleMenuItem>(procedureName,
  //                                                  new SqlParameter("@Id",menuItem_Id), 
  //                                                  new SqlParameter("@jsonValue", roleMenuItem.ToJson()));
  //      }
    }
}