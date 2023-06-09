
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class MeasurementUnit_Action
    {
		
        public static async Task<DataResult<MeasurementUnit>> SaveAttached(this MeasurementUnit measurementUnit, UserCredit userCredit)
        {
            var permissionType = measurementUnit.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(measurementUnit.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<MeasurementUnit>(-1, "You don't have Save Permission for ''MeasurementUnit''", measurementUnit);

            return await measurementUnit.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<MeasurementUnit>> SaveAttached(this MeasurementUnit measurementUnit, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IMeasurementUnitService measurementUnitService = new MeasurementUnitService();

            var result = await measurementUnitService.Save(measurementUnit, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<MeasurementUnit>(measurementUnit);

            Result childResult = null;

            if(measurementUnit.ListOfFunctionalKPI.CheckList())
            {
                measurementUnit.ListOfFunctionalKPI.ForEach(i => i.MeasurementUnit.Id = result.Id);

                childResult = await measurementUnit.ListOfFunctionalKPI.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<MeasurementUnit>(measurementUnit);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<MeasurementUnit>(measurementUnit);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<MeasurementUnit>> SaveCollection(this List<MeasurementUnit> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<MeasurementUnit> result = new SuccessfulDataResult<MeasurementUnit>();

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
