
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
    public static class CertificationType_Action
    {
		
        public static async Task<DataResult<CertificationType>> SaveAttached(this CertificationType certificationType, UserCredit userCredit)
        {
            var permissionType = certificationType.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(certificationType.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<CertificationType>(-1, "You don't have Save Permission for ''CertificationType''", certificationType);

            return await certificationType.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<CertificationType>> SaveAttached(this CertificationType certificationType, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICertificationTypeService certificationTypeService = new CertificationTypeService();

            var result = await certificationTypeService.Save(certificationType, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<CertificationType>(certificationType);

            Result childResult = null;

            if(certificationType.ListOfUniversityHistory.CheckList())
            {
                certificationType.ListOfUniversityHistory.ForEach(i => i.CertificationType.Id = result.Id);

                childResult = await certificationType.ListOfUniversityHistory.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<CertificationType>(certificationType);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<CertificationType>(certificationType);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<CertificationType>> SaveCollection(this List<CertificationType> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<CertificationType> result = new SuccessfulDataResult<CertificationType>();

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
