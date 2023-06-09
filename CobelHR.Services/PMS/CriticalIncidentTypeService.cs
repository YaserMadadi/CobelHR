using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;

namespace CobelHR.Services.PMS
{
    public class CriticalIncidentTypeService : Service<CriticalIncidentType>, ICriticalIncidentTypeService
    {
        public CriticalIncidentTypeService() : base()
        {
        }

        public override async Task<DataResult<CriticalIncidentType>> SaveAttached(CriticalIncidentType criticalIncidentType, UserCredit userCredit)
        {
            return await criticalIncidentType.SaveAttached(userCredit);
        }

        public DataResult<List<CriticalIncident>> CollectionOfCriticalIncident(int criticalIncidentType_Id, CriticalIncident criticalIncident, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CriticalIncidentType.CollectionOfCriticalIncident]";

            return this.CollectionOf<CriticalIncident>(procedureName,
                                                    new SqlParameter("@Id",criticalIncidentType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", criticalIncident.ToJson()));
        }
    }
}