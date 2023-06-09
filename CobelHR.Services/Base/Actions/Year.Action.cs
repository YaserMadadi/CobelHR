
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
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.Actions
{
    public static class Year_Action
    {
		
        public static async Task<DataResult<Year>> SaveAttached(this Year year, UserCredit userCredit)
        {
            var permissionType = year.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(year.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Year>(-1, "You don't have Save Permission for ''Year''", year);

            return await year.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Year>> SaveAttached(this Year year, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IYearService yearService = new YearService();

            var result = await yearService.Save(year, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Year>(year);

            Result childResult = null;

            if(year.ListOfTargetSetting.CheckList())
            {
                year.ListOfTargetSetting.ForEach(i => i.Year.Id = result.Id);

                childResult = await year.ListOfTargetSetting.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Year>(year);
                }
            }

            if(year.ListOfYearQuarter.CheckList())
            {
                year.ListOfYearQuarter.ForEach(i => i.Year.Id = result.Id);

                childResult = await year.ListOfYearQuarter.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Year>(year);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Year>(year);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Year>> SaveCollection(this List<Year> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Year> result = new SuccessfulDataResult<Year>();

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
