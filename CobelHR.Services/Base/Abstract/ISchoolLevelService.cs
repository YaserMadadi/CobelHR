using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface ISchoolLevelService : IService<SchoolLevel>
    {
        DataResult<List<SchoolHistory>> CollectionOfSchoolHistory(int schoolLevel_Id, SchoolHistory schoolHistory, UserCredit userCredit);
    }
}
