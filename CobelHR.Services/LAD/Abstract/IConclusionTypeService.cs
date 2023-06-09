using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.LAD;


namespace CobelHR.Services.LAD.Abstract
{
    public interface IConclusionTypeService : IService<ConclusionType>
    {
        DataResult<List<Conclusion>> CollectionOfConclusion(int conclusionType_Id, Conclusion conclusion, UserCredit userCredit);
    }
}
