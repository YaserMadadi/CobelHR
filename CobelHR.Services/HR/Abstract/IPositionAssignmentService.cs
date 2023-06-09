using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IPositionAssignmentService : IService<PositionAssignment>
    {
        DataResult<List<PositionAssignmentRepeal>> CollectionOfPositionAssignmentRepeal(int positionAssignment_Id, PositionAssignmentRepeal positionAssignmentRepeal, UserCredit userCredit);
    }
}
