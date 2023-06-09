using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IMaritalStatusService : IService<MaritalStatus>
    {
        DataResult<List<Person>> CollectionOfPerson(int maritalStatus_Id, Person person, UserCredit userCredit);
    }
}
