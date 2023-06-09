
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Abstract;
using CobelHR.Services.LAD.Actions;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.Base.Actions
{
    public static class YearQuarter_Action
    {
		
        public static async Task<DataResult<YearQuarter>> SaveAttached(this YearQuarter yearQuarter, UserCredit userCredit)
        {
            var permissionType = yearQuarter.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(yearQuarter.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<YearQuarter>(-1, "You don't have Save Permission for ''YearQuarter''", yearQuarter);

            return await yearQuarter.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<YearQuarter>> SaveAttached(this YearQuarter yearQuarter, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IYearQuarterService yearQuarterService = new YearQuarterService();

            var result = await yearQuarterService.Save(yearQuarter, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<YearQuarter>(yearQuarter);

            Result childResult = null;

            if(yearQuarter.ListOfDeadLine_AssessmentTraining.CheckList())
            {
                yearQuarter.ListOfDeadLine_AssessmentTraining.ForEach(i => i.DeadLine.Id = result.Id);

                childResult = await yearQuarter.ListOfDeadLine_AssessmentTraining.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<YearQuarter>(yearQuarter);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<YearQuarter>(yearQuarter);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<YearQuarter>> SaveCollection(this List<YearQuarter> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<YearQuarter> result = new SuccessfulDataResult<YearQuarter>();

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
