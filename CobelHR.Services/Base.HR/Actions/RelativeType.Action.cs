
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Actions
{
    public static class RelativeType_Action
    {
		
        public static async Task<DataResult<RelativeType>> SaveAttached(this RelativeType relativeType, UserCredit userCredit)
        {
            var permissionType = relativeType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(relativeType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<RelativeType>(-1, "You don't have Save Permission for ''RelativeType''", relativeType);

            return await relativeType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<RelativeType>> SaveAttached(this RelativeType relativeType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IRelativeTypeService relativeTypeService = new RelativeTypeService();

            var result = await relativeTypeService.Save(relativeType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<RelativeType>(relativeType);

            Result childResult = null;

            if(relativeType.ListOfRelationType_Relative.CheckList())
            {
                relativeType.ListOfRelationType_Relative.ForEach(i => i.RelationType.Id = result.Id);

                childResult = await relativeType.ListOfRelationType_Relative.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<RelativeType>(relativeType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<RelativeType>(relativeType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<RelativeType>> SaveCollection(this List<RelativeType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<RelativeType> result = new SuccessfulDataResult<RelativeType>();

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
