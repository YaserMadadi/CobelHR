
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
    public static class ConclusionType_Action
    {
		
        public static async Task<DataResult<ConclusionType>> SaveAttached(this ConclusionType conclusionType, UserCredit userCredit)
        {
            var permissionType = conclusionType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(conclusionType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<ConclusionType>(-1, "You don't have Save Permission for ''ConclusionType''", conclusionType);

            return await conclusionType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<ConclusionType>> SaveAttached(this ConclusionType conclusionType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IConclusionTypeService conclusionTypeService = new ConclusionTypeService();

            var result = await conclusionTypeService.Save(conclusionType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<ConclusionType>(conclusionType);

            Result childResult = null;

            if(conclusionType.ListOfConclusion.CheckList())
            {
                conclusionType.ListOfConclusion.ForEach(i => i.ConclusionType.Id = result.Id);

                childResult = await conclusionType.ListOfConclusion.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<ConclusionType>(conclusionType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<ConclusionType>(conclusionType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<ConclusionType>> SaveCollection(this List<ConclusionType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<ConclusionType> result = new SuccessfulDataResult<ConclusionType>();

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
