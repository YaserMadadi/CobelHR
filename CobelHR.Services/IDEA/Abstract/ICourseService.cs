using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.IDEA;


namespace CobelHR.Services.IDEA.Abstract
{
    public interface ICourseService : IService<Course>
    {
        DataResult<List<Training>> CollectionOfTraining(int course_Id, Training training, UserCredit userCredit);
    }
}
