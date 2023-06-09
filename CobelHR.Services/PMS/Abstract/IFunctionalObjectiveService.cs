using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IFunctionalObjectiveService : IService<FunctionalObjective>
    {
        DataResult<List<FunctionalKPI>> CollectionOfFunctionalKPI(int functionalObjective_Id, FunctionalKPI functionalKPI, UserCredit userCredit);

		DataResult<List<FunctionalObjective>> CollectionOfFunctionalObjective_ParentalFunctionalObjective(int functionalObjective_Id, FunctionalObjective functionalObjective, UserCredit userCredit);

		DataResult<List<FunctionalObjectiveComment>> CollectionOfFunctionalObjectiveComment(int functionalObjective_Id, FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit);
    }
}
