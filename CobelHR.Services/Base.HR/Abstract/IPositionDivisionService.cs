using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IPositionDivisionService : IService<PositionDivision>
    {
        DataResult<List<Position>> CollectionOfPosition(int positionDivision_Id, Position position, UserCredit userCredit);

		DataResult<List<Unit>> CollectionOfUnit(int positionDivision_Id, Unit unit, UserCredit userCredit);
    }
}
