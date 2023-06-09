
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
    public static class HabitancyType_Action
    {
		
        public static async Task<DataResult<HabitancyType>> SaveAttached(this HabitancyType habitancyType, UserCredit userCredit)
        {
            var permissionType = habitancyType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(habitancyType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<HabitancyType>(-1, "You don't have Save Permission for ''HabitancyType''", habitancyType);

            return await habitancyType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<HabitancyType>> SaveAttached(this HabitancyType habitancyType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IHabitancyTypeService habitancyTypeService = new HabitancyTypeService();

            var result = await habitancyTypeService.Save(habitancyType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<HabitancyType>(habitancyType);

            Result childResult = null;

            if(habitancyType.ListOfHabitancy.CheckList())
            {
                habitancyType.ListOfHabitancy.ForEach(i => i.HabitancyType.Id = result.Id);

                childResult = await habitancyType.ListOfHabitancy.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<HabitancyType>(habitancyType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<HabitancyType>(habitancyType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<HabitancyType>> SaveCollection(this List<HabitancyType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<HabitancyType> result = new SuccessfulDataResult<HabitancyType>();

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
