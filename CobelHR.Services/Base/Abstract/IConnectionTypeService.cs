using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IConnectionTypeService : IService<ConnectionType>
    {
        DataResult<List<AssessorConnectionLine>> CollectionOfAssessorConnectionLine(int connectionType_Id, AssessorConnectionLine assessorConnectionLine, UserCredit userCredit);

		DataResult<List<CoachConnectionLine>> CollectionOfCoachConnectionLine(int connectionType_Id, CoachConnectionLine coachConnectionLine, UserCredit userCredit);

		DataResult<List<PersonConnection>> CollectionOfPersonConnection(int connectionType_Id, PersonConnection personConnection, UserCredit userCredit);
    }
}
