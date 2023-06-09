using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Actions;
using CobelHR.Services.PMS.Pharma.Abstract;

namespace CobelHR.Services.PMS.Pharma
{
    public class KPIService : Service<KPI>, IKPIService
    {
        public KPIService() : base()
        {
        }

        public override async Task<DataResult<KPI>> SaveAttached(KPI kpi, UserCredit userCredit)
        {
            return await kpi.SaveAttached(userCredit);
        }

        public DataResult<List<Appraise>> CollectionOfAppraise(int kpi_Id, Appraise Appraise, UserCredit userCredit)
        {
            var procedureName = "[PMS.Pharma].[KPI.CollectionOfAppraise]";

            return this.CollectionOf<Appraise>(procedureName,
                                                    new SqlParameter("@Id",kpi_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", Appraise.ToJson()));
        }
    }
}