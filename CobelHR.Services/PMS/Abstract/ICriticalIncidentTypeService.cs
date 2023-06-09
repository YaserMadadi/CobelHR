using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface ICriticalIncidentTypeService : IService<CriticalIncidentType>
    {
        DataResult<List<CriticalIncident>> CollectionOfCriticalIncident(int criticalIncidentType_Id, CriticalIncident criticalIncident, UserCredit userCredit);
    }
}
