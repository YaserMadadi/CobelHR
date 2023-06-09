using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;using CobelHR.Entities.LAD;


namespace CobelHR.Services.PMS
{
    public class CompetencyItemService : Service<CompetencyItem>, ICompetencyItemService
    {
        public CompetencyItemService() : base()
        {
        }

        public override async Task<DataResult<CompetencyItem>> SaveAttached(CompetencyItem competencyItem, UserCredit userCredit)
        {
            return await competencyItem.SaveAttached(userCredit);
        }

        public DataResult<List<AssessmentScore>> CollectionOfAssessmentScore(int competencyItem_Id, AssessmentScore assessmentScore, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CompetencyItem.CollectionOfAssessmentScore]";

            return this.CollectionOf<AssessmentScore>(procedureName,
                                                    new SqlParameter("@Id",competencyItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentScore.ToJson()));
        }

		public DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int competencyItem_Id, BehavioralObjective behavioralObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CompetencyItem.CollectionOfBehavioralObjective]";

            return this.CollectionOf<BehavioralObjective>(procedureName,
                                                    new SqlParameter("@Id",competencyItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralObjective.ToJson()));
        }

		public DataResult<List<CompetencyItemKPI>> CollectionOfCompetencyItemKPI(int competencyItem_Id, CompetencyItemKPI competencyItemKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CompetencyItem.CollectionOfCompetencyItemKPI]";

            return this.CollectionOf<CompetencyItemKPI>(procedureName,
                                                    new SqlParameter("@Id",competencyItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", competencyItemKPI.ToJson()));
        }

		public DataResult<List<DevelopmentPlanCompetency>> CollectionOfDevelopmentPlanCompetency(int competencyItem_Id, DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CompetencyItem.CollectionOfDevelopmentPlanCompetency]";

            return this.CollectionOf<DevelopmentPlanCompetency>(procedureName,
                                                    new SqlParameter("@Id",competencyItem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", developmentPlanCompetency.ToJson()));
        }
    }
}