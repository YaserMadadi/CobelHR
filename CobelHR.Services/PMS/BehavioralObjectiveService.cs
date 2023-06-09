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
    public class BehavioralObjectiveService : Service<BehavioralObjective>, IBehavioralObjectiveService
    {
        public BehavioralObjectiveService() : base()
        {
        }

        public override async Task<DataResult<BehavioralObjective>> SaveAttached(BehavioralObjective behavioralObjective, UserCredit userCredit)
        {
            return await behavioralObjective.SaveAttached(userCredit);
        }

        public DataResult<List<BehavioralKPI>> CollectionOfBehavioralKPI(int behavioralObjective_Id, BehavioralKPI behavioralKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[BehavioralObjective.CollectionOfBehavioralKPI]";

            return this.CollectionOf<BehavioralKPI>(procedureName,
                                                    new SqlParameter("@Id",behavioralObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralKPI.ToJson()));
        }
    }
}