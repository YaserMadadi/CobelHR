
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
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.HR.Actions
{
    public static class Level_Action
    {
		
        public static async Task<DataResult<Level>> SaveAttached(this Level level, UserCredit userCredit)
        {
            var permissionType = level.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(level.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Level>(-1, "You don't have Save Permission for ''Level''", level);

            return await level.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Level>> SaveAttached(this Level level, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ILevelService levelService = new LevelService();

            var result = await levelService.Save(level, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Level>(level);

            Result childResult = null;

            if(level.ListOfObjectiveWeightNonOperational.CheckList())
            {
                level.ListOfObjectiveWeightNonOperational.ForEach(i => i.Level.Id = result.Id);

                childResult = await level.ListOfObjectiveWeightNonOperational.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Level>(level);
                }
            }

            if(level.ListOfPosition.CheckList())
            {
                level.ListOfPosition.ForEach(i => i.Level.Id = result.Id);

                childResult = await level.ListOfPosition.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Level>(level);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Level>(level);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Level>> SaveCollection(this List<Level> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Level> result = new SuccessfulDataResult<Level>();

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
