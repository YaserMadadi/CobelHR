
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
    public static class ExcemptionType_Action
    {
		
        public static async Task<DataResult<ExcemptionType>> SaveAttached(this ExcemptionType excemptionType, UserCredit userCredit)
        {
            var permissionType = excemptionType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(excemptionType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ExcemptionType>(-1, "You don't have Save Permission for ''ExcemptionType''", excemptionType);

            return await excemptionType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ExcemptionType>> SaveAttached(this ExcemptionType excemptionType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IExcemptionTypeService excemptionTypeService = new ExcemptionTypeService();

            var result = await excemptionTypeService.Save(excemptionType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ExcemptionType>(excemptionType);

            Result childResult = null;

            if(excemptionType.ListOfMilitaryServiceExcemption.CheckList())
            {
                excemptionType.ListOfMilitaryServiceExcemption.ForEach(i => i.ExcemptionType.Id = result.Id);

                childResult = await excemptionType.ListOfMilitaryServiceExcemption.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ExcemptionType>(excemptionType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ExcemptionType>(excemptionType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ExcemptionType>> SaveCollection(this List<ExcemptionType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ExcemptionType> result = new SuccessfulDataResult<ExcemptionType>();

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
