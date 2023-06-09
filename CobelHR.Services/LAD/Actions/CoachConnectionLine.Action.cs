
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
    public static class CoachConnectionLine_Action
    {
		
        public static async Task<DataResult<CoachConnectionLine>> SaveAttached(this CoachConnectionLine coachConnectionLine, UserCredit userCredit)
        {
            var permissionType = coachConnectionLine.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(coachConnectionLine.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CoachConnectionLine>(-1, "You don't have Save Permission for ''CoachConnectionLine''", coachConnectionLine);

            return await coachConnectionLine.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CoachConnectionLine>> SaveAttached(this CoachConnectionLine coachConnectionLine, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICoachConnectionLineService coachConnectionLineService = new CoachConnectionLineService();

            var result = await coachConnectionLineService.Save(coachConnectionLine, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CoachConnectionLine>(coachConnectionLine);

            

            if (depth > 0)

                return new SuccessfulDataResult<CoachConnectionLine>(coachConnectionLine);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CoachConnectionLine>> SaveCollection(this List<CoachConnectionLine> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CoachConnectionLine> result = new SuccessfulDataResult<CoachConnectionLine>();

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
