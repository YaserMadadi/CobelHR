
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
    public static class PersonDrivingLicense_Action
    {
		
        public static async Task<DataResult<PersonDrivingLicense>> SaveAttached(this PersonDrivingLicense personDrivingLicense, UserCredit userCredit)
        {
            var permissionType = personDrivingLicense.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(personDrivingLicense.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PersonDrivingLicense>(-1, "You don't have Save Permission for ''PersonDrivingLicense''", personDrivingLicense);

            return await personDrivingLicense.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PersonDrivingLicense>> SaveAttached(this PersonDrivingLicense personDrivingLicense, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPersonDrivingLicenseService personDrivingLicenseService = new PersonDrivingLicenseService();

            var result = await personDrivingLicenseService.Save(personDrivingLicense, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PersonDrivingLicense>(personDrivingLicense);

            

            if (depth > 0)

                return new SuccessfulDataResult<PersonDrivingLicense>(personDrivingLicense);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PersonDrivingLicense>> SaveCollection(this List<PersonDrivingLicense> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PersonDrivingLicense> result = new SuccessfulDataResult<PersonDrivingLicense>();

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
