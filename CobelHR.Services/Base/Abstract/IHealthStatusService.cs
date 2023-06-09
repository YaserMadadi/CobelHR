using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IHealthStatusService : IService<HealthStatus>
    {
        DataResult<List<Person>> CollectionOfPerson(int healthStatus_Id, Person person, UserCredit userCredit);
    }
}
