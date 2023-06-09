using CobelHR.Entities.Core;
using CobelHR.Entities.PMS;
using CobelHR.Services.HR.Abstract;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.HR.Abstract
{
    public interface IEmployeeServicePartial : IEmployeeService
    {
        public DataResult<List<RolePermission>> LoadRolePermission(int employee_id);

        public DataResult<List<TargetSetting>> LoadTargetSetting(int employee_id, TargetSetting targetSetting);

    }
}
