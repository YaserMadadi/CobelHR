using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IAssessorService : IService<Assessor>
    {
        DataResult<List<Assessment>> CollectionOfAssessment(int assessor_Id, Assessment assessment, UserCredit userCredit);

		DataResult<List<AssessorConnectionLine>> CollectionOfAssessorConnectionLine(int assessor_Id, AssessorConnectionLine assessorConnectionLine, UserCredit userCredit);
    }
}
