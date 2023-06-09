
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
    public static class Coaching_Action
    {
		
        public static async Task<DataResult<Coaching>> SaveAttached(this Coaching coaching, UserCredit userCredit)
        {
            var permissionType = coaching.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coaching.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Coaching>(-1, "You don't have Save Permission for ''Coaching''", coaching);

            return await coaching.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Coaching>> SaveAttached(this Coaching coaching, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachingService coachingService = new CoachingService();

            var result = await coachingService.Save(coaching, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Coaching>(coaching);

            Result childResult = null;

            if(coaching.ListOfAssessmentCoaching.CheckList())
            {
                coaching.ListOfAssessmentCoaching.ForEach(i => i.Coaching.Id = result.Id);

                childResult = await coaching.ListOfAssessmentCoaching.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Coaching>(coaching);
                }
            }

            if(coaching.ListOfCoachingSession.CheckList())
            {
                coaching.ListOfCoachingSession.ForEach(i => i.Coaching.Id = result.Id);

                childResult = await coaching.ListOfCoachingSession.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Coaching>(coaching);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Coaching>(coaching);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Coaching>> SaveCollection(this List<Coaching> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Coaching> result = new SuccessfulDataResult<Coaching>();

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
