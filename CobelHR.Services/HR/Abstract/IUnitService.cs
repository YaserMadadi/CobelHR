using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IUnitService : IService<Unit>
    {
        DataResult<List<Position>> CollectionOfPosition(int unit_Id, Position position, UserCredit userCredit);
    }
}
