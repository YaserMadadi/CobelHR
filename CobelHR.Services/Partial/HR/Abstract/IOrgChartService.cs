using CobelHR.Entities.Core;
using CobelHR.Entities.PMS;
using CobelHR.Services.HR.Abstract;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CobelHR.Entities.Partial.HR;

namespace CobelHR.Services.Partial.HR.Abstract
{
    public interface IOrgChartService : IService<OrgChart>
    {
        public DataResult<List<OrgChart>> LoadOrgChart(int id);

    }
}
