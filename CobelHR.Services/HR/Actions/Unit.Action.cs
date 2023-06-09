
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Abstract;


namespace CobelHR.Services.HR.Actions
{
    public static class Unit_Action
    {
		
        public static async Task<DataResult<Unit>> SaveAttached(this Unit unit, UserCredit userCredit)
        {
            var permissionType = unit.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(unit.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Unit>(-1, "You don't have Save Permission for ''Unit''", unit);

            return await unit.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Unit>> SaveAttached(this Unit unit, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IUnitService unitService = new UnitService();

            var result = await unitService.Save(unit, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Unit>(unit);

            Result childResult = null;

            if(unit.ListOfPosition.CheckList())
            {
                unit.ListOfPosition.ForEach(i => i.Unit.Id = result.Id);

                childResult = await unit.ListOfPosition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Unit>(unit);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Unit>(unit);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Unit>> SaveCollection(this List<Unit> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Unit> result = new SuccessfulDataResult<Unit>();

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
