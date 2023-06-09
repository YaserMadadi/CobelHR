using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IAppraiseTypeService : IService<AppraiseType>
    {
        DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int appraiseType_Id, AppraiseResult appraiseResult, UserCredit userCredit);

		DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise(int appraiseType_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit);

		DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise(int appraiseType_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit);

		DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise(int appraiseType_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit);
    }
}
