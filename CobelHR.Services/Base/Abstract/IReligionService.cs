using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IReligionService : IService<Religion>
    {
        DataResult<List<Person>> CollectionOfPerson(int religion_Id, Person person, UserCredit userCredit);
    }
}
