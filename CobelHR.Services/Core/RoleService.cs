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
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService() : base()
        {
        }

        public override async Task<DataResult<Role>> SaveAttached(Role role, UserCredit userCredit)
        {
            return await role.SaveAttached(userCredit);
        }

        public DataResult<List<RoleMember>> CollectionOfRoleMember(int role_Id, RoleMember roleMember, UserCredit userCredit)
        {
            var procedureName = "[Core].[Role.CollectionOfRoleMember]";

            return this.CollectionOf<RoleMember>(procedureName,
                                                    new SqlParameter("@Id",role_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", roleMember.ToJson()));
        }

		//public DataResult<List<RoleMenuItem>> CollectionOfRoleMenuItem(int role_Id, RoleMenuItem roleMenuItem, UserCredit userCredit)
  //      {
  //          var procedureName = "[Core].[Role.CollectionOfRoleMenuItem]";

  //          return this.CollectionOf<RoleMenuItem>(procedureName,
  //                                                  new SqlParameter("@Id",role_Id), 
  //                                                  new SqlParameter("@jsonValue", roleMenuItem.ToJson()));
  //      }

		public DataResult<List<RolePermission>> CollectionOfRolePermission(int role_Id, RolePermission rolePermission, UserCredit userCredit)
        {
            var procedureName = "[Core].[Role.CollectionOfRolePermission]";

            return this.CollectionOf<RolePermission>(procedureName,
                                                    new SqlParameter("@Id",role_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", rolePermission.ToJson()));
        }
    }
}