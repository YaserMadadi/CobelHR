
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
    public static class Country_Action
    {
		
        public static async Task<DataResult<Country>> SaveAttached(this Country country, UserCredit userCredit)
        {
            var permissionType = country.IsNew ? PermissionType.Add : PermissionType.Edit;

            var hasPermission = permissionType.CheckPermission(country.Info, userCredit);

            if (!hasPermission)

                return new ErrorDataResult<Country>(-1, "You don't have Save Permission for ''Country''", country);

            return await country.SaveAttached(userCredit, new CoreTransaction());
        }

        public static async Task<DataResult<Country>> SaveAttached(this Country country, UserCredit userCredit, CoreTransaction transaction, int depth = 0)
        {
            ICountryService countryService = new CountryService();

            var result = await countryService.Save(country, userCredit, transaction);

            if (result.Id <= 0)

                return result.ToDataResult<Country>(country);

            Result childResult = null;

            if(country.ListOfNationality_Person.CheckList())
            {
                country.ListOfNationality_Person.ForEach(i => i.Nationality.Id = result.Id);

                childResult = await country.ListOfNationality_Person.SaveCollection(userCredit, transaction, depth + 1);
            
                if (childResult.Id <= 0)
                {
                    return childResult.ToDataResult<Country>(country);
                }
            }


            if (depth > 0)

                return new SuccessfulDataResult<Country>(country);;

            transaction.Commit();

            return result;
        }


        
        public static async Task<DataResult<Country>> SaveCollection(this List<Country> list, UserCredit userCredit, CoreTransaction transaction, int depth)
        {
            DataResult<Country> result = new SuccessfulDataResult<Country>();

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
