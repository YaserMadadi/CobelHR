using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IGenderService : IService<Gender>
    {
        DataResult<List<Assessor>> CollectionOfAssessor(int gender_Id, Assessor assessor, UserCredit userCredit);

		DataResult<List<Coach>> CollectionOfCoach(int gender_Id, Coach coach, UserCredit userCredit);

		DataResult<List<Person>> CollectionOfPerson(int gender_Id, Person person, UserCredit userCredit);
    }
}
