using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Actions;
using CobelHR.Services.LAD.Abstract;

namespace CobelHR.Services.LAD
{
    public class PromotionAssessmentService : Service<PromotionAssessment>, IPromotionAssessmentService
    {
        public PromotionAssessmentService() : base()
        {
        }

        public override async Task<DataResult<PromotionAssessment>> SaveAttached(PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            return await promotionAssessment.SaveAttached(userCredit);
        }

        
    }
}