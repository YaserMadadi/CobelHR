using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface ICountryService : IService<Country>
    {
        DataResult<List<Person>> CollectionOfPerson_Nationality(int country_Id, Person person, UserCredit userCredit);
    }
}
