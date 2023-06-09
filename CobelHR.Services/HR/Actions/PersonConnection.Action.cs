
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
    public static class PersonConnection_Action
    {
		
        public static async Task<DataResult<PersonConnection>> SaveAttached(this PersonConnection personConnection, UserCredit userCredit)
        {
            var permissionType = personConnection.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(personConnection.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<PersonConnection>(-1, "You don't have Save Permission for ''PersonConnection''", personConnection);

            return await personConnection.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<PersonConnection>> SaveAttached(this PersonConnection personConnection, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IPersonConnectionService personConnectionService = new PersonConnectionService();

            var result = await personConnectionService.Save(personConnection, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<PersonConnection>(personConnection);

            

            if (depth > 0)

                return new SuccessfulDataResult<PersonConnection>(personConnection);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<PersonConnection>> SaveCollection(this List<PersonConnection> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<PersonConnection> result = new SuccessfulDataResult<PersonConnection>();

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
