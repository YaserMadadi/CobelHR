using CobelHR.Entities.Core;
using CobelHR.Entities.PMS;
using CobelHR.Services.HR;
using CobelHR.Services.Partial.HR.Abstract;
using EssentialCore.DataAccess;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.Tools.Serializer;
using System.Data.SqlClient;
using EssentialCore.Entities;
using CobelHR.Entities.Partial.HR;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Pagination;
using EssentialCore.BusinessLogic;

namespace CobelHR.Services.Partial.HR
{
    public class OrgChartService : Service<OrgChart>, IOrgChartService
    {
        public DataResult<List<OrgChart>> LoadOrgChart(int id)
        {
            var dataResult = UserClass.CreateCommand("[HR].[OrgChart.RetrieveAll]",
                                                        new SqlParameter("@Parent_Id",id))
                                                        .ExecuteDataResult<List<OrgChart>>(JsonType.Collection);

            return dataResult.Result;
        }
    }
}
