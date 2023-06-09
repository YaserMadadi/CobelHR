using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class CountryService : Service<Country>, ICountryService
    {
        public CountryService() : base()
        {
        }

        public override async Task<DataResult<Country>> SaveAttached(Country country, UserCredit userCredit)
        {
            return await country.SaveAttached(userCredit);
        }

        public DataResult<List<Person>> CollectionOfPerson_Nationality(int country_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base].[Country(Nationality).CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",country_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }
    }
}