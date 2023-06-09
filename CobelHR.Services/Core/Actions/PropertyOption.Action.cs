
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
    public static class PropertyOption_Action
    {
		
        public static async Task<DataResult<PropertyOption>> SaveAttached(this PropertyOption propertyOption, UserCredit userCredit)
        {
            var permissionType = propertyOption.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(propertyOption.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PropertyOption>(-1, "You don't have Save Permission for ''PropertyOption''", propertyOption);

            return await propertyOption.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PropertyOption>> SaveAttached(this PropertyOption propertyOption, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPropertyOptionService propertyOptionService = new PropertyOptionService();

            var result = await propertyOptionService.Save(propertyOption, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PropertyOption>(propertyOption);

            

            if (depth > 0)

                return new SuccessfulDataResult<PropertyOption>(propertyOption);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PropertyOption>> SaveCollection(this List<PropertyOption> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PropertyOption> result = new SuccessfulDataResult<PropertyOption>();

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
