
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
    public static class Passport_Action
    {
		
        public static async Task<DataResult<Passport>> SaveAttached(this Passport passport, UserCredit userCredit)
        {
            var permissionType = passport.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(passport.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Passport>(-1, "You don't have Save Permission for ''Passport''", passport);

            return await passport.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Passport>> SaveAttached(this Passport passport, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPassportService passportService = new PassportService();

            var result = await passportService.Save(passport, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Passport>(passport);

            

            if (depth > 0)

                return new SuccessfulDataResult<Passport>(passport);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Passport>> SaveCollection(this List<Passport> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Passport> result = new SuccessfulDataResult<Passport>();

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
