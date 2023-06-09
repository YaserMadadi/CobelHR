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
    public class QualitativeKPIService : Service<QualitativeKPI>, IQualitativeKPIService
    {
        public QualitativeKPIService() : base()
        {
        }

        public override async Task<DataResult<QualitativeKPI>> SaveAttached(QualitativeKPI qualitativeKPI, UserCredit userCredit)
        {
            return await qualitativeKPI.SaveAttached(userCredit);
        }

        public DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise(int qualitativeKPI_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[QualitativeKPI.CollectionOfQualitativeAppraise]";

            return this.CollectionOf<QualitativeAppraise>(procedureName,
                                                    new SqlParameter("@Id",qualitativeKPI_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", qualitativeAppraise.ToJson()));
        }
    }
}