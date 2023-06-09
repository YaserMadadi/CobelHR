
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
    public static class FeedbackSession_Action
    {
		
        public static async Task<DataResult<FeedbackSession>> SaveAttached(this FeedbackSession feedbackSession, UserCredit userCredit)
        {
            var permissionType = feedbackSession.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(feedbackSession.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FeedbackSession>(-1, "You don't have Save Permission for ''FeedbackSession''", feedbackSession);

            return await feedbackSession.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FeedbackSession>> SaveAttached(this FeedbackSession feedbackSession, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFeedbackSessionService feedbackSessionService = new FeedbackSessionService();

            var result = await feedbackSessionService.Save(feedbackSession, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FeedbackSession>(feedbackSession);

            

            if (depth > 0)

                return new SuccessfulDataResult<FeedbackSession>(feedbackSession);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FeedbackSession>> SaveCollection(this List<FeedbackSession> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FeedbackSession> result = new SuccessfulDataResult<FeedbackSession>();

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
