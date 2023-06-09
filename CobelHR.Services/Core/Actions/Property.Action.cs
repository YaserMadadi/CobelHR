
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
    public static class Property_Action
    {
		
        public static async Task<DataResult<Property>> SaveAttached(this Property property, UserCredit userCredit)
        {
            var permissionType = property.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(property.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Property>(-1, "You don't have Save Permission for ''Property''", property);

            return await property.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Property>> SaveAttached(this Property property, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPropertyService propertyService = new PropertyService();

            var result = await propertyService.Save(property, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Property>(property);

            Result childResult = null;

            if(property.ListOfPropertyOption.CheckList())
            {
                property.ListOfPropertyOption.ForEach(i => i.Property.Id = result.Id);

                childResult = await property.ListOfPropertyOption.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Property>(property);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Property>(property);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Property>> SaveCollection(this List<Property> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Property> result = new SuccessfulDataResult<Property>();

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
