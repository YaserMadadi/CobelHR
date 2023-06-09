
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;


namespace CobelHR.Services.PMS.Actions
{
    public static class ObjectiveWeightNonOperational_Action
    {
		
        public static async Task<DataResult<ObjectiveWeightNonOperational>> SaveAttached(this ObjectiveWeightNonOperational objectiveWeightNonOperational, UserCredit userCredit)
        {
            var permissionType = objectiveWeightNonOperational.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(objectiveWeightNonOperational.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ObjectiveWeightNonOperational>(-1, "You don't have Save Permission for ''ObjectiveWeightNonOperational''", objectiveWeightNonOperational);

            return await objectiveWeightNonOperational.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ObjectiveWeightNonOperational>> SaveAttached(this ObjectiveWeightNonOperational objectiveWeightNonOperational, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IObjectiveWeightNonOperationalService objectiveWeightNonOperationalService = new ObjectiveWeightNonOperationalService();

            var result = await objectiveWeightNonOperationalService.Save(objectiveWeightNonOperational, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ObjectiveWeightNonOperational>(objectiveWeightNonOperational);

            

            if (depth > 0)

                return new SuccessfulDataResult<ObjectiveWeightNonOperational>(objectiveWeightNonOperational);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ObjectiveWeightNonOperational>> SaveCollection(this List<ObjectiveWeightNonOperational> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ObjectiveWeightNonOperational> result = new SuccessfulDataResult<ObjectiveWeightNonOperational>();

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
