using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class EventTypeService : Service<EventType>, IEventTypeService
    {
        public EventTypeService() : base()
        {
        }

        public override async Task<DataResult<EventType>> SaveAttached(EventType eventType, UserCredit userCredit)
        {
            return await eventType.SaveAttached(userCredit);
        }

        public DataResult<List<EmployeeEvent>> CollectionOfEmployeeEvent(int eventType_Id, EmployeeEvent employeeEvent, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[EventType.CollectionOfEmployeeEvent]";

            return this.CollectionOf<EmployeeEvent>(procedureName,
                                                    new SqlParameter("@Id",eventType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeEvent.ToJson()));
        }
    }
}