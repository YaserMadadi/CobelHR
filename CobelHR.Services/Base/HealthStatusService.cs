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
    public class HealthStatusService : Service<HealthStatus>, IHealthStatusService
    {
        public HealthStatusService() : base()
        {
        }

        public override async Task<DataResult<HealthStatus>> SaveAttached(HealthStatus healthStatus, UserCredit userCredit)
        {
            return await healthStatus.SaveAttached(userCredit);
        }

        public DataResult<List<Person>> CollectionOfPerson(int healthStatus_Id, Person person, UserCredit userCredit)
        {
            var procedureName = "[Base].[HealthStatus.CollectionOfPerson]";

            return this.CollectionOf<Person>(procedureName,
                                                    new SqlParameter("@Id",healthStatus_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", person.ToJson()));
        }
    }
}