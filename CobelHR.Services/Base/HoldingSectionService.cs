using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class HoldingSectionService : Service<HoldingSection>, IHoldingSectionService
    {
        public HoldingSectionService() : base()
        {
        }

        public override async Task<DataResult<HoldingSection>> SaveAttached(HoldingSection holdingSection, UserCredit userCredit)
        {
            return await holdingSection.SaveAttached(userCredit);
        }

        public DataResult<List<Employee>> CollectionOfEmployee_LastHoldingSection(int holdingSection_Id, Employee employee, UserCredit userCredit)
        {
            var procedureName = "[Base].[HoldingSection(LastHoldingSection).CollectionOfEmployee]";

            return this.CollectionOf<Employee>(procedureName,
                                                    new SqlParameter("@Id",holdingSection_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employee.ToJson()));
        }

		public DataResult<List<EmployeeDetail>> CollectionOfEmployeeDetail(int holdingSection_Id, EmployeeDetail employeeDetail, UserCredit userCredit)
        {
            var procedureName = "[Base].[HoldingSection.CollectionOfEmployeeDetail]";

            return this.CollectionOf<EmployeeDetail>(procedureName,
                                                    new SqlParameter("@Id",holdingSection_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", employeeDetail.ToJson()));
        }
    }
}