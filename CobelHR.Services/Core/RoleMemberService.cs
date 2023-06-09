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
    public class RoleMemberService : Service<RoleMember>, IRoleMemberService
    {
        public RoleMemberService() : base()
        {
        }

        public override async Task<DataResult<RoleMember>> SaveAttached(RoleMember roleMember, UserCredit userCredit)
        {
            return await roleMember.SaveAttached(userCredit);
        }

        
    }
}