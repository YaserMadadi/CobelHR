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
    public class EmploymentStatusService : Service<EmploymentStatus>, IEmploymentStatusService
    {
        public EmploymentStatusService() : base()
        {
        }

        public override async Task<DataResult<EmploymentStatus>> SaveAttached(EmploymentStatus employmentStatus, UserCredit userCredit)
        {
            return await employmentStatus.SaveAttached(userCredit);
        }

        public DataResult<List<Employee>> CollectionOfEmployee(int employmentStatus_Id, Employee employee, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[EmploymentStatus.CollectionOfEmployee]";

            return this.CollectionOf<Employee>(procedureName,
                                                    new SqlParameter("@Id",employmentStatus_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employee.ToJson()));
        }

		public DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int employmentStatus_Id, EmployeeDetail employeeDetail, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[EmploymentStatus.CollectionOfEmployeeDetail]";

            return this.CollectionOf<EmployeeDetail>(procedureName,
                                                    new SqlParameter("@Id",employmentStatus_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeDetail.ToJson()));
        }
    }
}