
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using EssentialCore.Entities;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Permission;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Abstract;
using CobelHR.Services.PMS.Actions;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS.Actions
{
    public static class AppraiseType_Action
    {
		
        public static async Task<DataResult<AppraiseType>> SaveAttached(this AppraiseType appraiseType, UserCredit userCredit)
        {
            var permissionType = appraiseType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(appraiseType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<AppraiseType>(-1, "You don't have Save Permission for ''AppraiseType''", appraiseType);

            return await appraiseType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<AppraiseType>> SaveAttached(this AppraiseType appraiseType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IAppraiseTypeService appraiseTypeService = new AppraiseTypeService();

            var result = await appraiseTypeService.Save(appraiseType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<AppraiseType>(appraiseType);

            Result childResult = null;

            if(appraiseType.ListOfAppraiseResult.CheckList())
            {
                appraiseType.ListOfAppraiseResult.ForEach(i => i.AppraiseType.Id = result.Id);

                childResult = await appraiseType.ListOfAppraiseResult.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AppraiseType>(appraiseType);
                }
            }

            if(appraiseType.ListOfBehavioralAppraise.CheckList())
            {
                appraiseType.ListOfBehavioralAppraise.ForEach(i => i.AppraiseType.Id = result.Id);

                childResult = await appraiseType.ListOfBehavioralAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AppraiseType>(appraiseType);
                }
            }

            if(appraiseType.ListOfFunctionalAppraise.CheckList())
            {
                appraiseType.ListOfFunctionalAppraise.ForEach(i => i.AppraiseType.Id = result.Id);

                childResult = await appraiseType.ListOfFunctionalAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AppraiseType>(appraiseType);
                }
            }

            if(appraiseType.ListOfQualitativeAppraise.CheckList())
            {
                appraiseType.ListOfQualitativeAppraise.ForEach(i => i.AppraiseType.Id = result.Id);

                childResult = await appraiseType.ListOfQualitativeAppraise.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<AppraiseType>(appraiseType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<AppraiseType>(appraiseType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<AppraiseType>> SaveCollection(this List<AppraiseType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<AppraiseType> result = new SuccessfulDataResult<AppraiseType>();

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
