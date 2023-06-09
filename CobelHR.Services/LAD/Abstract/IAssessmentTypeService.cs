using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IAssessmentTypeService : IService<AssessmentType>
    {
        DataResult<List<Assessment>> CollectionOfAssessment(int assessmentType_Id, Assessment assessment, UserCredit userCredit);
    }
}
