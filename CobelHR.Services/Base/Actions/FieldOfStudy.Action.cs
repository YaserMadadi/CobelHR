
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
    public static class FieldOfStudy_Action
    {
		
        public static async Task<DataResult<FieldOfStudy>> SaveAttached(this FieldOfStudy fieldOfStudy, UserCredit userCredit)
        {
            var permissionType = fieldOfStudy.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(fieldOfStudy.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<FieldOfStudy>(-1, "You don't have Save Permission for ''FieldOfStudy''", fieldOfStudy);

            return await fieldOfStudy.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<FieldOfStudy>> SaveAttached(this FieldOfStudy fieldOfStudy, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IFieldOfStudyService fieldOfStudyService = new FieldOfStudyService();

            var result = await fieldOfStudyService.Save(fieldOfStudy, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<FieldOfStudy>(fieldOfStudy);

            Result childResult = null;

            if(fieldOfStudy.ListOfUniversityHistory.CheckList())
            {
                fieldOfStudy.ListOfUniversityHistory.ForEach(i => i.FieldOfStudy.Id = result.Id);

                childResult = await fieldOfStudy.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<FieldOfStudy>(fieldOfStudy);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<FieldOfStudy>(fieldOfStudy);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<FieldOfStudy>> SaveCollection(this List<FieldOfStudy> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<FieldOfStudy> result = new SuccessfulDataResult<FieldOfStudy>();

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
