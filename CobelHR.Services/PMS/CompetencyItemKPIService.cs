using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.Services.PMS
{
    public class CompetencyItemKPIService : Service<CompetencyItemKPI>, ICompetencyItemKPIService
    {
        public CompetencyItemKPIService() : base()
        {
        }

        public override async Task<DataResult<CompetencyItemKPI>> SaveAttached(CompetencyItemKPI competencyItemKPI, UserCredit userCredit)
        {
            return await competencyItemKPI.SaveAttached(userCredit);
        }

        public DataResult<List<BehavioralKPI>> CollectionOfBehavioralKPI(int competencyItemKPI_Id, BehavioralKPI behavioralKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CompetencyItemKPI.CollectionOfBehavioralKPI]";

            return this.CollectionOf<BehavioralKPI>(procedureName,
                                                    new SqlParameter("@Id",competencyItemKPI_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralKPI.ToJson()));
        }
    }
}