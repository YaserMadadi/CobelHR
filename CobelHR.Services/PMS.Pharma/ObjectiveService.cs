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
    public class ObjectiveService : Service<Objective>, IObjectiveService
    {
        public ObjectiveService() : base()
        {
        }

        public override async Task<DataResult<Objective>> SaveAttached(Objective objective, UserCredit userCredit)
        {
            return await objective.SaveAttached(userCredit);
        }

        public DataResult<List<KPI>> CollectionOfKPI(int objective_Id, KPI kpi, UserCredit userCredit)
        {
            var procedureName = "[PMS.Pharma].[Objective.CollectionOfKPI]";

            return this.CollectionOf<KPI>(procedureName,
                                                    new SqlParameter("@Id",objective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", kpi.ToJson()));
        }
    }
}