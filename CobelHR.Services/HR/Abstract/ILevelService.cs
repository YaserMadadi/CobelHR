using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.HR;using CobelHR.Entities.PMS;



namespace CobelHR.Services.HR.Abstract
{
    public interface ILevelService : IService<Level>
    {
        DataResult<List<ObjectiveWeightNonOperational>> CollectionOfObjectiveWeightNonOperational(int level_Id, ObjectiveWeightNonOperational objectiveWeightNonOperational, UserCredit userCredit);

		DataResult<List<Position>> CollectionOfPosition(int level_Id, Position position, UserCredit userCredit);
    }
}
