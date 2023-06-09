using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class MaritalStatusService : Service<MaritalStatus>, IMaritalStatusService
    {
        public MaritalStatusService() : base()
        {
        }

        public override async Task<DataResult<MaritalStatus>> SaveAttached(MaritalStatus maritalStatus, UserCredit userCredit)
        {
            return await maritalStatus.SaveAttached(userCredit);
        }

        public DataResult<List<Person>> CollectionOfPerson(int maritalStatus_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[MaritalStatus.CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",maritalStatus_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }
    }
}