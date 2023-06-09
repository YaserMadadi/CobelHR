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
    public class QualitativeObjectiveService : Service<QualitativeObjective>, IQualitativeObjectiveService
    {
        public QualitativeObjectiveService() : base()
        {
        }

        public override async Task<DataResult<QualitativeObjective>> SaveAttached(QualitativeObjective qualitativeObjective, UserCredit userCredit)
        {
            return await qualitativeObjective.SaveAttached(userCredit);
        }

        public DataResult<List<QualitativeKPI>> CollectionOfQualitativeKPI(int qualitativeObjective_Id, QualitativeKPI qualitativeKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[QualitativeObjective.CollectionOfQualitativeKPI]";

            return this.CollectionOf<QualitativeKPI>(procedureName,
                                                    new SqlParameter("@Id",qualitativeObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", qualitativeKPI.ToJson()));
        }
    }
}