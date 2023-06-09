
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


namespace CobelHR.Services.Base.Actions
{
    public static class Province_Action
    {
		
        public static async Task<DataResult<Province>> SaveAttached(this Province province, UserCredit userCredit)
        {
            var permissionType = province.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(province.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Province>(-1, "You don't have Save Permission for ''Province''", province);

            return await province.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Province>> SaveAttached(this Province province, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            IProvinceService provinceService = new ProvinceService();

            var result = await provinceService.Save(province, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Province>(province);

            Result childResult = null;

            if(province.ListOfCity.CheckList())
            {
                province.ListOfCity.ForEach(i => i.Province.Id = result.Id);

                childResult = await province.ListOfCity.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Province>(province);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Province>(province);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Province>> SaveCollection(this List<Province> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Province> result = new SuccessfulDataResult<Province>();

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
