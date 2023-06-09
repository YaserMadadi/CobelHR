
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
    public static class DrivingLicenseType_Action
    {
		
        public static async Task<DataResult<DrivingLicenseType>> SaveAttached(this DrivingLicenseType drivingLicenseType, UserCredit userCredit)
        {
            var permissionType = drivingLicenseType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(drivingLicenseType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<DrivingLicenseType>(-1, "You don't have Save Permission for ''DrivingLicenseType''", drivingLicenseType);

            return await drivingLicenseType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<DrivingLicenseType>> SaveAttached(this DrivingLicenseType drivingLicenseType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IDrivingLicenseTypeService drivingLicenseTypeService = new DrivingLicenseTypeService();

            var result = await drivingLicenseTypeService.Save(drivingLicenseType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<DrivingLicenseType>(drivingLicenseType);

            Result childResult = null;

            if(drivingLicenseType.ListOfPersonDrivingLicense.CheckList())
            {
                drivingLicenseType.ListOfPersonDrivingLicense.ForEach(i => i.DrivingLicenseType.Id = result.Id);

                childResult = await drivingLicenseType.ListOfPersonDrivingLicense.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<DrivingLicenseType>(drivingLicenseType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<DrivingLicenseType>(drivingLicenseType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<DrivingLicenseType>> SaveCollection(this List<DrivingLicenseType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<DrivingLicenseType> result = new SuccessfulDataResult<DrivingLicenseType>();

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
