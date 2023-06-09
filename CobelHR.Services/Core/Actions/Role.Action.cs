
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
    public static class Role_Action
    {
		
        public static async Task<DataResult<Role>> SaveAttached(this Role role, UserCredit userCredit)
        {
            var permissionType = role.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(role.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Role>(-1, "You don't have Save Permission for ''Role''", role);

            return await role.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Role>> SaveAttached(this Role role, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IRoleService roleService = new RoleService();

            var result = await roleService.Save(role, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Role>(role);

            Result childResult = null;

            if(role.ListOfRoleMember.CheckList())
            {
                role.ListOfRoleMember.ForEach(i => i.Role.Id = result.Id);

                childResult = await role.ListOfRoleMember.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Role>(role);
                }
            }

            if(role.ListOfRolePermission.CheckList())
            {
                role.ListOfRolePermission.ForEach(i => i.Role.Id = result.Id);

                childResult = await role.ListOfRolePermission.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Role>(role);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Role>(role);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Role>> SaveCollection(this List<Role> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Role> result = new SuccessfulDataResult<Role>();

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
