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
    public class RolePermissionService : Service<RolePermission>, IRolePermissionService
    {
        public RolePermissionService() : base()
        {
        }

        public override async Task<DataResult<RolePermission>> SaveAttached(RolePermission rolePermission, UserCredit userCredit)
        {
            return await rolePermission.SaveAttached(userCredit);
        }

        
    }
}