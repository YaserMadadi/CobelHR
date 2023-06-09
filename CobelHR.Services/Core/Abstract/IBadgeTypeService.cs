using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IBadgeTypeService : IService<BadgeType>
    {
        DataResult<List<Badge>> CollectionOfBadge(int badgeType_Id, Badge badge, UserCredit userCredit);
    }
}
