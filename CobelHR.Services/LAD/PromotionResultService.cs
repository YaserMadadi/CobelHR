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
    public class PromotionResultService : Service<PromotionResult>, IPromotionResultService
    {
        public PromotionResultService() : base()
        {
        }

        public override async Task<DataResult<PromotionResult>> SaveAttached(PromotionResult promotionResult, UserCredit userCredit)
        {
            return await promotionResult.SaveAttached(userCredit);
        }

        public DataResult<List<PromotionAssessment>> CollectionOfPromotionAssessment(int promotionResult_Id, PromotionAssessment promotionAssessment, UserCredit userCredit)
        {
            var procedureName = "[LAD].[PromotionResult.CollectionOfPromotionAssessment]";

            return this.CollectionOf<PromotionAssessment>(procedureName,
                                                    new SqlParameter("@Id",promotionResult_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", promotionAssessment.ToJson()));
        }
    }
}