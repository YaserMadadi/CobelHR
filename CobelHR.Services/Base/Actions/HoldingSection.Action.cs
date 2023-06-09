
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
    public static class HoldingSection_Action
    {
		
        public static async Task<DataResult<HoldingSection>> SaveAttached(this HoldingSection holdingSection, UserCredit userCredit)
        {
            var permissionType = holdingSection.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(holdingSection.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<HoldingSection>(-1, "You don't have Save Permission for ''HoldingSection''", holdingSection);

            return await holdingSection.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<HoldingSection>> SaveAttached(this HoldingSection holdingSection, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IHoldingSectionService holdingSectionService = new HoldingSectionService();

            var result = await holdingSectionService.Save(holdingSection, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<HoldingSection>(holdingSection);

            Result childResult = null;

            if(holdingSection.ListOfLastHoldingSection_Employee.CheckList())
            {
                holdingSection.ListOfLastHoldingSection_Employee.ForEach(i => i.LastHoldingSection.Id = result.Id);

                childResult = await holdingSection.ListOfLastHoldingSection_Employee.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<HoldingSection>(holdingSection);
                }
            }

            if(holdingSection.ListOfEmployeeDetail.CheckList())
            {
                holdingSection.ListOfEmployeeDetail.ForEach(i => i.HoldingSection.Id = result.Id);

                childResult = await holdingSection.ListOfEmployeeDetail.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<HoldingSection>(holdingSection);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<HoldingSection>(holdingSection);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<HoldingSection>> SaveCollection(this List<HoldingSection> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<HoldingSection> result = new SuccessfulDataResult<HoldingSection>();

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
