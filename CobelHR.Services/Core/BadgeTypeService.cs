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
    public class BadgeTypeService : Service<BadgeType>, IBadgeTypeService
    {
        public BadgeTypeService() : base()
        {
        }

        public override async Task<DataResult<BadgeType>> SaveAttached(BadgeType badgeType, UserCredit userCredit)
        {
            return await badgeType.SaveAttached(userCredit);
        }

        public DataResult<List<Badge>> CollectionOfBadge(int badgeType_Id, Badge badge, UserCredit userCredit)
        {
            var procedureName = "[Core].[BadgeType.CollectionOfBadge]";

            return this.CollectionOf<Badge>(procedureName,
                                                    new SqlParameter("@Id",badgeType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", badge.ToJson()));
        }
    }
}