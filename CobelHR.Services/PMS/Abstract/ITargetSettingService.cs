using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.Services.PMS.Abstract
{
    public interface ITargetSettingService : IService<TargetSetting>
    {
        DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int targetSetting_Id, AppraiseResult appraiseResult, UserCredit userCredit);

		DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int targetSetting_Id, BehavioralObjective behavioralObjective, UserCredit userCredit);

		DataResult<List<FinalAppraise>> CollectionOfFinalAppraise(int targetSetting_Id, FinalAppraise finalAppraise, UserCredit userCredit);

		DataResult<List<FunctionalObjective>> CollectionOfFunctionalObjective(int targetSetting_Id, FunctionalObjective functionalObjective, UserCredit userCredit);

		DataResult<List<QualitativeObjective>> CollectionOfQualitativeObjective(int targetSetting_Id, QualitativeObjective qualitativeObjective, UserCredit userCredit);

		DataResult<List<QuantitativeAppraise>> CollectionOfQuantitativeAppraise(int targetSetting_Id, QuantitativeAppraise quantitativeAppraise, UserCredit userCredit);

        DataResult<List<Objective>> CollectionOfObjective(int targetSetting_Id, Objective objective, UserCredit userCredit);
    }
}
