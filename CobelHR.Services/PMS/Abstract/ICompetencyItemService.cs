using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;using CobelHR.Entities.LAD;



namespace CobelHR.Services.PMS.Abstract
{
    public interface ICompetencyItemService : IService<CompetencyItem>
    {
        DataResult<List<AssessmentScore>> CollectionOfAssessmentScore(int competencyItem_Id, AssessmentScore assessmentScore, UserCredit userCredit);

		DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int competencyItem_Id, BehavioralObjective behavioralObjective, UserCredit userCredit);

		DataResult<List<CompetencyItemKPI>> CollectionOfCompetencyItemKPI(int competencyItem_Id, CompetencyItemKPI competencyItemKPI, UserCredit userCredit);

		DataResult<List<DevelopmentPlanCompetency>> CollectionOfDevelopmentPlanCompetency(int competencyItem_Id, DevelopmentPlanCompetency developmentPlanCompetency, UserCredit userCredit);
    }
}
