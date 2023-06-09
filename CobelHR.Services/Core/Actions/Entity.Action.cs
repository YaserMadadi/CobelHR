
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
    public static class Entity_Action
    {
		
        public static async Task<DataResult<Entity>> SaveAttached(this Entity entity, UserCredit userCredit)
        {
            var permissionType = entity.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(entity.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Entity>(-1, "You don't have Save Permission for ''Entity''", entity);

            return await entity.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Entity>> SaveAttached(this Entity entity, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IEntityService entityService = new EntityService();

            var result = await entityService.Save(entity, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Entity>(entity);

            Result childResult = null;

            if(entity.ListOfProperty.CheckList())
            {
                entity.ListOfProperty.ForEach(i => i.Entity.Id = result.Id);

                childResult = await entity.ListOfProperty.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Entity>(entity);
                }
            }

            if(entity.ListOfRolePermission.CheckList())
            {
                entity.ListOfRolePermission.ForEach(i => i.Entity.Id = result.Id);

                childResult = await entity.ListOfRolePermission.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Entity>(entity);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Entity>(entity);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Entity>> SaveCollection(this List<Entity> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Entity> result = new SuccessfulDataResult<Entity>();

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
