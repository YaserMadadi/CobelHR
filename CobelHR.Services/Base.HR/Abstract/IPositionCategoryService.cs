using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IPositionCategoryService : IService<PositionCategory>
    {
        DataResult<List<AppraisalApproverConfig>> CollectionOfAppraisalApproverConfig(int positionCategory_Id, AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit);

		DataResult<List<ConfigTargetSetting>> CollectionOfConfigTargetSetting(int positionCategory_Id, ConfigTargetSetting configTargetSetting, UserCredit userCredit);

        DataResult<List<PharmaConfigTargetSetting>> CollectionOfPharmaConfigTargetSetting(int positionCategory_Id, PharmaConfigTargetSetting pharmaConfigTargetSetting, UserCredit userCredit);

        DataResult<List<Position>> CollectionOfPosition(int positionCategory_Id, Position position, UserCredit userCredit);
    }
}
