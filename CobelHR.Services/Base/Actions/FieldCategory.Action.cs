
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class FieldCategory_Action
    {
		
        public static async Task<DataResult<FieldCategory>> SaveAttached(this FieldCategory fieldCategory, UserCredit userCredit)
        {
            var permissionType = fieldCategory.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(fieldCategory.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FieldCategory>(-1, "You don't have Save Permission for ''FieldCategory''", fieldCategory);

            return await fieldCategory.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FieldCategory>> SaveAttached(this FieldCategory fieldCategory, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFieldCategoryService fieldCategoryService = new FieldCategoryService();

            var result = await fieldCategoryService.Save(fieldCategory, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FieldCategory>(fieldCategory);

            Result childResult = null;

            if(fieldCategory.ListOfPersonCertificate.CheckList())
            {
                fieldCategory.ListOfPersonCertificate.ForEach(i => i.FieldCategory.Id = result.Id);

                childResult = await fieldCategory.ListOfPersonCertificate.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FieldCategory>(fieldCategory);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<FieldCategory>(fieldCategory);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FieldCategory>> SaveCollection(this List<FieldCategory> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FieldCategory> result = new SuccessfulDataResult<FieldCategory>();

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
