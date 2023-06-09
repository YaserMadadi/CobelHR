
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
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class ConnectionType_Action
    {
		
        public static async Task<DataResult<ConnectionType>> SaveAttached(this ConnectionType connectionType, UserCredit userCredit)
        {
            var permissionType = connectionType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(connectionType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConnectionType>(-1, "You don't have Save Permission for ''ConnectionType''", connectionType);

            return await connectionType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConnectionType>> SaveAttached(this ConnectionType connectionType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConnectionTypeService connectionTypeService = new ConnectionTypeService();

            var result = await connectionTypeService.Save(connectionType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConnectionType>(connectionType);

            Result childResult = null;

            if(connectionType.ListOfAssessorConnectionLine.CheckList())
            {
                connectionType.ListOfAssessorConnectionLine.ForEach(i => i.ConnectionType.Id = result.Id);

                childResult = await connectionType.ListOfAssessorConnectionLine.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConnectionType>(connectionType);
                }
            }

            if(connectionType.ListOfCoachConnectionLine.CheckList())
            {
                connectionType.ListOfCoachConnectionLine.ForEach(i => i.ConnectionType.Id = result.Id);

                childResult = await connectionType.ListOfCoachConnectionLine.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConnectionType>(connectionType);
                }
            }

            if(connectionType.ListOfPersonConnection.CheckList())
            {
                connectionType.ListOfPersonConnection.ForEach(i => i.ConnectionType.Id = result.Id);

                childResult = await connectionType.ListOfPersonConnection.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConnectionType>(connectionType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ConnectionType>(connectionType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConnectionType>> SaveCollection(this List<ConnectionType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConnectionType> result = new SuccessfulDataResult<ConnectionType>();

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
