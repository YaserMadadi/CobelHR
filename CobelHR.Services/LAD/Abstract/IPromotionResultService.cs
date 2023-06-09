using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IPromotionResultService : IService<PromotionResult>
    {
        DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment(int promotionResult_Id, PromotionAssessment promotionAssessment, UserCredit userCredit);
    }
}
