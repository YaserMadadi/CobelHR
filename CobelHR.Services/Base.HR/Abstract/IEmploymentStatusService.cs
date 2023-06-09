using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IEmploymentStatusService : IService<EmploymentStatus>
    {
        DataResult<List<Employee>> CollectionOfEmployee(int employmentStatus_Id, Employee employee, UserCredit userCredit);

		DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employmentStatus_Id, EmployeeDetail employeeDetail, UserCredit userCredit);
    }
}
