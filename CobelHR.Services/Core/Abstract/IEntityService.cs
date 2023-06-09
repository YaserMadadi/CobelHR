using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IEntityService : IService<Entity>
    {
        DataResult<List<Property>> CollectionOfProperty(int entity_Id, Property property, UserCredit userCredit);

		DataResult<List<RolePermission>> CollectionOfRolePermission(int entity_Id, RolePermission rolePermission, UserCredit userCredit);
    }
}
