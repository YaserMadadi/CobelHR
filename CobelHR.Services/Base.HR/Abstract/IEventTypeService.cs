using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IEventTypeService : IService<EventType>
    {
        DataResult<List<EmployeeEvent>> CollectionOfEmployeeEvent(int eventType_Id, EmployeeEvent employeeEvent, UserCredit userCredit);
    }
}
