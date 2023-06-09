using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IHoldingSectionService : IService<HoldingSection>
    {
        DataResult<List<Employee>> CollectionOfEmployee_LastHoldingSection(int holdingSection_Id, Employee employee, UserCredit userCredit);

		DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int holdingSection_Id, EmployeeDetail employeeDetail, UserCredit userCredit);
    }
}
