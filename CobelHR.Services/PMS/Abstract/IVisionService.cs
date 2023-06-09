using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IVisionService : IService<Vision>
    {
        DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int vision_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit);

		DataResult<List<VisionApproved>> CollectionOfVisionApproved(int vision_Id, VisionApproved visionApproved, UserCredit userCredit);

		DataResult<List<VisionComment>> CollectionOfVisionComment(int vision_Id, VisionComment visionComment, UserCredit userCredit);
    }
}
