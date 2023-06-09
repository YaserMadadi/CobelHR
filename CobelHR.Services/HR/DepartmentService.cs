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
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        public DepartmentService() : base()
        {
        }

        public override async Task<DataResult<Department>> SaveAttached(Department department, UserCredit userCredit)
        {
            return await department.SaveAttached(userCredit);
        }

        public DataResult<List<Unit>> CollectionOfUnit(int department_Id, Unit unit, UserCredit userCredit)
        {
            var procedureName = "[HR].[Department.CollectionOfUnit]";

            return this.CollectionOf<Unit>(procedureName,
                                                    new SqlParameter("@Id",department_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", unit.ToJson()));
        }
    }
}