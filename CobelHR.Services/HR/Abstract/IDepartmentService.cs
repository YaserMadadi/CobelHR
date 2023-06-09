using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;


namespace CobelHR.Services.HR.Abstract
{
    public interface IDepartmentService : IService<Department>
    {
        DataResult<List<Unit>> CollectionOfUnit(int department_Id, Unit unit, UserCredit userCredit);
    }
}
