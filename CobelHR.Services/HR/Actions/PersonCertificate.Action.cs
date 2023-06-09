
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
    public static class PersonCertificate_Action
    {
		
        public static async Task<DataResult<PersonCertificate>> SaveAttached(this PersonCertificate personCertificate, UserCredit userCredit)
        {
            var permissionType = personCertificate.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(personCertificate.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PersonCertificate>(-1, "You don't have Save Permission for ''PersonCertificate''", personCertificate);

            return await personCertificate.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PersonCertificate>> SaveAttached(this PersonCertificate personCertificate, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPersonCertificateService personCertificateService = new PersonCertificateService();

            var result = await personCertificateService.Save(personCertificate, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PersonCertificate>(personCertificate);

            

            if (depth > 0)

                return new SuccessfulDataResult<PersonCertificate>(personCertificate);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PersonCertificate>> SaveCollection(this List<PersonCertificate> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PersonCertificate> result = new SuccessfulDataResult<PersonCertificate>();

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
