
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.IDEA;
using CobelHR.Services.IDEA.Abstract;


namespace CobelHR.Services.IDEA.Actions
{
    public static class Training_Action
    {
		
        public static async Task<DataResult<Training>> SaveAttached(this Training training, UserCredit userCredit)
        {
            var permissionType = training.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(training.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Training>(-1, "You don't have Save Permission for ''Training''", training);

            return await training.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Training>> SaveAttached(this Training training, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ITrainingService trainingService = new TrainingService();

            var result = await trainingService.Save(training, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Training>(training);

            

            if (depth > 0)

                return new SuccessfulDataResult<Training>(training);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Training>> SaveCollection(this List<Training> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Training> result = new SuccessfulDataResult<Training>();

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
