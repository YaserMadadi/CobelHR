using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class EmployeeEventService : Service<EmployeeEvent>, IEmployeeEventService
    {
        public EmployeeEventService() : base()
        {
        }

        public override async Task<DataResult<EmployeeEvent>> SaveAttached(EmployeeEvent employeeEvent, UserCredit userCredit)
        {
            return await employeeEvent.SaveAttached(userCredit);
        }

        
    }
}