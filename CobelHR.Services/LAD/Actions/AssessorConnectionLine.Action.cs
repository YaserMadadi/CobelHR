
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
    public static class AssessorConnectionLine_Action
    {
		
        public static async Task<DataResult<AssessorConnectionLine>> SaveAttached(this AssessorConnectionLine assessorConnectionLine, UserCredit userCredit)
        {
            var permissionType = assessorConnectionLine.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(assessorConnectionLine.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AssessorConnectionLine>(-1, "You don't have Save Permission for ''AssessorConnectionLine''", assessorConnectionLine);

            return await assessorConnectionLine.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AssessorConnectionLine>> SaveAttached(this AssessorConnectionLine assessorConnectionLine, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAssessorConnectionLineService assessorConnectionLineService = new AssessorConnectionLineService();

            var result = await assessorConnectionLineService.Save(assessorConnectionLine, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AssessorConnectionLine>(assessorConnectionLine);

            

            if (depth > 0)

                return new SuccessfulDataResult<AssessorConnectionLine>(assessorConnectionLine);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AssessorConnectionLine>> SaveCollection(this List<AssessorConnectionLine> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AssessorConnectionLine> result = new SuccessfulDataResult<AssessorConnectionLine>();

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
