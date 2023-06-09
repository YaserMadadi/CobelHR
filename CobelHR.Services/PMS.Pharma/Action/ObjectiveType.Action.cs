
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Abstract;


namespace CobelHR.Services.PMS.Pharma.Actions
{
    public static class ObjectiveType_Action
    {
		
        public static async Task<DataResult<ObjectiveType>> SaveAttached(this ObjectiveType objectiveType, UserCredit userCredit)
        {
            var permissionType = objectiveType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(objectiveType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ObjectiveType>(-1, "You don't have Save Permission for ''ObjectiveType''", objectiveType);

            return await objectiveType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ObjectiveType>> SaveAttached(this ObjectiveType objectiveType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IObjectiveTypeService objectiveTypeService = new ObjectiveTypeService();

            var result = await objectiveTypeService.Save(objectiveType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ObjectiveType>(objectiveType);

            Result childResult = null;

            if(objectiveType.ListOfObjective.CheckList())
            {
                objectiveType.ListOfObjective.ForEach(i => i.ObjectiveType.Id = result.Id);

                childResult = await objectiveType.ListOfObjective.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ObjectiveType>(objectiveType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ObjectiveType>(objectiveType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ObjectiveType>> SaveCollection(this List<ObjectiveType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ObjectiveType> result = new SuccessfulDataResult<ObjectiveType>();

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
