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
    public class BehavioralKPIService : Service<BehavioralKPI>, IBehavioralKPIService
    {
        public BehavioralKPIService() : base()
        {
        }

        public override async Task<DataResult<BehavioralKPI>> SaveAttached(BehavioralKPI behavioralKPI, UserCredit userCredit)
        {
            return await behavioralKPI.SaveAttached(userCredit);
        }

        public DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise(int behavioralKPI_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[BehavioralKPI.CollectionOfBehavioralAppraise]";

            return this.CollectionOf<BehavioralAppraise>(procedureName,
                                                    new SqlParameter("@Id",behavioralKPI_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralAppraise.ToJson()));
        }
    }
}