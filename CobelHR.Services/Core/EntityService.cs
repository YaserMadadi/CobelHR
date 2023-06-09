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
    public class EntityService : Service<Entity>, IEntityService
    {
        public EntityService() : base()
        {
        }

        public override async Task<DataResult<Entity>> SaveAttached(Entity entity, UserCredit userCredit)
        {
            return await entity.SaveAttached(userCredit);
        }

        public DataResult<List<Property>> CollectionOfProperty(int entity_Id, Property property, UserCredit userCredit)
        {
            var procedureName = "[Core].[Entity.CollectionOfProperty]";

            return this.CollectionOf<Property>(procedureName,
                                                    new SqlParameter("@Id",entity_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", property.ToJson()));
        }

		public DataResult<List<RolePermission>> CollectionOfRolePermission(int entity_Id, RolePermission rolePermission, UserCredit userCredit)
        {
            var procedureName = "[Core].[Entity.CollectionOfRolePermission]";

            return this.CollectionOf<RolePermission>(procedureName,
                                                    new SqlParameter("@Id",entity_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", rolePermission.ToJson()));
        }
    }
}