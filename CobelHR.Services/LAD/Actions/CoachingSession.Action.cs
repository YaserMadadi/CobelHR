
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
    public static class CoachingSession_Action
    {
		
        public static async Task<DataResult<CoachingSession>> SaveAttached(this CoachingSession coachingSession, UserCredit userCredit)
        {
            var permissionType = coachingSession.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coachingSession.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CoachingSession>(-1, "You don't have Save Permission for ''CoachingSession''", coachingSession);

            return await coachingSession.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CoachingSession>> SaveAttached(this CoachingSession coachingSession, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachingSessionService coachingSessionService = new CoachingSessionService();

            var result = await coachingSessionService.Save(coachingSession, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CoachingSession>(coachingSession);

            

            if (depth > 0)

                return new SuccessfulDataResult<CoachingSession>(coachingSession);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CoachingSession>> SaveCollection(this List<CoachingSession> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CoachingSession> result = new SuccessfulDataResult<CoachingSession>();

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
