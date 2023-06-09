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
    public class CriticalIncidentService : Service<CriticalIncident>, ICriticalIncidentService
    {
        public CriticalIncidentService() : base()
        {
        }

        public override async Task<DataResult<CriticalIncident>> SaveAttached(CriticalIncident criticalIncident, UserCredit userCredit)
        {
            return await criticalIncident.SaveAttached(userCredit);
        }

        public DataResult<List<CriticalIncidentRecognition>> CollectionOfCriticalIncidentRecognition(int criticalIncident_Id, CriticalIncidentRecognition criticalIncidentRecognition, UserCredit userCredit)
        {
            var procedureName = "[PMS].[CriticalIncident.CollectionOfCriticalIncidentRecognition]";

            return this.CollectionOf<CriticalIncidentRecognition>(procedureName,
                                                    new SqlParameter("@Id",criticalIncident_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", criticalIncidentRecognition.ToJson()));
        }
    }
}