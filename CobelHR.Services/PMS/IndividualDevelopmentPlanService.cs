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
    public class IndividualDevelopmentPlanService : Service<IndividualDevelopmentPlan>, IIndividualDevelopmentPlanService
    {
        public IndividualDevelopmentPlanService() : base()
        {
        }

        public override async Task<DataResult<IndividualDevelopmentPlan>> SaveAttached(IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            return await individualDevelopmentPlan.SaveAttached(userCredit);
        }

        public DataResult<List<DevelopmentPlanCompetency>> CollectionOfDevelopmentPlanCompetency(int individualDevelopmentPlan_Id, DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit)
        {
            var procedureName = "[PMS].[IndividualDevelopmentPlan.CollectionOfDevelopmentPlanCompetency]";

            return this.CollectionOf<DevelopmentPlanCompetency>(procedureName,
                                                    new SqlParameter("@Id",individualDevelopmentPlan_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", developmentPlanCompetency.ToJson()));
        }
    }
}