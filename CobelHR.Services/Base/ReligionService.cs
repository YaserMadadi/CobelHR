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
    public class ReligionService : Service<Religion>, IReligionService
    {
        public ReligionService() : base()
        {
        }

        public override async Task<DataResult<Religion>> SaveAttached(Religion religion, UserCredit userCredit)
        {
            return await religion.SaveAttached(userCredit);
        }

        public DataResult<List<Person>> CollectionOfPerson(int religion_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base].[Religion.CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",religion_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }
    }
}