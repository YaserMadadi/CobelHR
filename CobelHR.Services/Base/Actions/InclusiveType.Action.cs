
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
    public static class InclusiveType_Action
    {
		
        public static async Task<DataResult<InclusiveType>> SaveAttached(this InclusiveType inclusiveType, UserCredit userCredit)
        {
            var permissionType = inclusiveType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(inclusiveType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<InclusiveType>(-1, "You don't have Save Permission for ''InclusiveType''", inclusiveType);

            return await inclusiveType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<InclusiveType>> SaveAttached(this InclusiveType inclusiveType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IInclusiveTypeService inclusiveTypeService = new InclusiveTypeService();

            var result = await inclusiveTypeService.Save(inclusiveType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<InclusiveType>(inclusiveType);

            Result childResult = null;

            if(inclusiveType.ListOfMilitaryServiceInclusive.CheckList())
            {
                inclusiveType.ListOfMilitaryServiceInclusive.ForEach(i => i.InclusiveType.Id = result.Id);

                childResult = await inclusiveType.ListOfMilitaryServiceInclusive.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<InclusiveType>(inclusiveType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<InclusiveType>(inclusiveType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<InclusiveType>> SaveCollection(this List<InclusiveType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<InclusiveType> result = new SuccessfulDataResult<InclusiveType>();

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
