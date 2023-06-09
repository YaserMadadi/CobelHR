using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class GenderService : Service<Gender>, IGenderService
    {
        public GenderService() : base()
        {
        }

        public override async Task<DataResult<Gender>> SaveAttached(Gender gender, UserCredit userCredit)
        {
            return await gender.SaveAttached(userCredit);
        }

        public DataResult<List<Assessor>> CollectionOfAssessor(int gender_Id, Assessor assessor, UserCredit userCredit)
        {
            var procedureName = "[Base].[Gender.CollectionOfAssessor]";

            return this.CollectionOf<Assessor>(procedureName,
                                                    new SqlParameter("@Id",gender_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessor.ToJson()));
        }

		public DataResult<List<Coach>> CollectionOfCoach(int gender_Id, Coach coach, UserCredit userCredit)
        {
            var procedureName = "[Base].[Gender.CollectionOfCoach]";

            return this.CollectionOf<Coach>(procedureName,
                                                    new SqlParameter("@Id",gender_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coach.ToJson()));
        }

		public DataResult<List<Person>> CollectionOfPerson(int gender_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base].[Gender.CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",gender_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }
    }
}