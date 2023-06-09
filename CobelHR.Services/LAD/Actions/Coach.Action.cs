
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Abstract;


namespace CobelHR.Services.LAD.Actions
{
    public static class Coach_Action
    {
		
        public static async Task<DataResult<Coach>> SaveAttached(this Coach coach, UserCredit userCredit)
        {
            var permissionType = coach.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coach.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Coach>(-1, "You don't have Save Permission for ''Coach''", coach);

            return await coach.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Coach>> SaveAttached(this Coach coach, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachService coachService = new CoachService();

            var result = await coachService.Save(coach, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Coach>(coach);

            Result childResult = null;

            if(coach.ListOfCoachConnectionLine.CheckList())
            {
                coach.ListOfCoachConnectionLine.ForEach(i => i.Coach.Id = result.Id);

                childResult = await coach.ListOfCoachConnectionLine.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Coach>(coach);
                }
            }

            if(coach.ListOfCoaching.CheckList())
            {
                coach.ListOfCoaching.ForEach(i => i.Coach.Id = result.Id);

                childResult = await coach.ListOfCoaching.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Coach>(coach);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Coach>(coach);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Coach>> SaveCollection(this List<Coach> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Coach> result = new SuccessfulDataResult<Coach>();

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
