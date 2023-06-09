using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;


namespace CobelHR.Services.PMS.Pharma.Abstract
{
    public interface IObjectiveTypeService : IService<ObjectiveType>
    {
        DataResult<List<Objective>> CollectionOfObjective(int objectiveType_Id, Objective objective, UserCredit userCredit);
    }
}
