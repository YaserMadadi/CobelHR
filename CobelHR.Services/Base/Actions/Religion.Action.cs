
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
using CobelHR.Services.HR.Actions;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.Actions
{
    public static class Religion_Action
    {
		
        public static async Task<DataResult<Religion>> SaveAttached(this Religion religion, UserCredit userCredit)
        {
            var permissionType = religion.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(religion.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Religion>(-1, "You don't have Save Permission for ''Religion''", religion);

            return await religion.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Religion>> SaveAttached(this Religion religion, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IReligionService religionService = new ReligionService();

            var result = await religionService.Save(religion, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Religion>(religion);

            Result childResult = null;

            if(religion.ListOfPerson.CheckList())
            {
                religion.ListOfPerson.ForEach(i => i.Religion.Id = result.Id);

                childResult = await religion.ListOfPerson.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Religion>(religion);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Religion>(religion);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Religion>> SaveCollection(this List<Religion> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Religion> result = new SuccessfulDataResult<Religion>();

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
