using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface ICriticalIncidentService : IService<CriticalIncident>
    {
        DataResult<List<CriticalIncidentRecognition>> CollectionOfCriticalIncidentRecognition(int criticalIncident_Id, CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit);
    }
}
