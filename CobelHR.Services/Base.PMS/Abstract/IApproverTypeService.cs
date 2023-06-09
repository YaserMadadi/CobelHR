using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IApproverTypeService : IService<ApproverType>
    {
        DataResult<List<AppraisalApproverConfig>> CollectionOfAppraisalApproverConfig(int approverType_Id, AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit);
    }
}
