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
    /// <summary>
    /// This is a test Comment
    /// </summary>
    public class CityService : Service<City>, ICityService
    {
        public CityService() : base()
        {
        }

        //test

        public override async Task<DataResult<City>> SaveAttached(City city, UserCredit userCredit)
        {
            return await city.SaveAttached(userCredit);
        }

        public DataResult<List<Habitancy>> CollectionOfHabitancy(int city_Id, Habitancy habitancy, UserCredit userCredit)
        {
            var procedureName = "[Base].[City.CollectionOfHabitancy]";

            return this.CollectionOf<Habitancy>(procedureName,
                                                    new SqlParameter("@Id",city_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", habitancy.ToJson()));
        }

		public DataResult<List<Person>> CollectionOfPerson_BirthCity(int city_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base].[City(BirthCity).CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",city_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }

		public DataResult<List<University>> CollectionOfUniversity(int city_Id, University university, UserCredit userCredit)
        {
            var procedureName = "[Base].[City.CollectionOfUniversity]";

            return this.CollectionOf<University>(procedureName,
                                                    new SqlParameter("@Id",city_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", university.ToJson()));
        }
    }
}