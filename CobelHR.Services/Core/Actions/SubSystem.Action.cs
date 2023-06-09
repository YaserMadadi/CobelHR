
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
    public static class SubSystem_Action
    {
		
        public static async Task<DataResult<SubSystem>> SaveAttached(this SubSystem subSystem, UserCredit userCredit)
        {
            var permissionType = subSystem.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(subSystem.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<SubSystem>(-1, "You don't have Save Permission for ''SubSystem''", subSystem);

            return await subSystem.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<SubSystem>> SaveAttached(this SubSystem subSystem, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ISubSystemService subSystemService = new SubSystemService();

            var result = await subSystemService.Save(subSystem, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<SubSystem>(subSystem);

            Result childResult = null;

            if(subSystem.ListOfMenu.CheckList())
            {
                subSystem.ListOfMenu.ForEach(i => i.SubSystem.Id = result.Id);

                childResult = await subSystem.ListOfMenu.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<SubSystem>(subSystem);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<SubSystem>(subSystem);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<SubSystem>> SaveCollection(this List<SubSystem> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<SubSystem> result = new SuccessfulDataResult<SubSystem>();

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
