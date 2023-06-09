using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IHabitancyTypeService : IService<HabitancyType>
    {
        DataResult<List<Habitancy>> CollectionOfHabitancy(int habitancyType_Id, Habitancy habitancy, UserCredit userCredit);
    }
}
