using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IApprovementTypeService : IService<ApprovementType>
    {
        DataResult<List<VisionApproved>> CollectionOfVisionApproved(int approvementType_Id, VisionApproved visionApproved, UserCredit userCredit);
    }
}
