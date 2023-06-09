using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS
{
    public class ExpectedLevelService : Service<ExpectedLevel>, IExpectedLevelService
    {
        public ExpectedLevelService() : base()
        {
        }

        public override async Task<DataResult<ExpectedLevel>> SaveAttached(ExpectedLevel expectedLevel, UserCredit userCredit)
        {
            return await expectedLevel.SaveAttached(userCredit);
        }

        public DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int expectedLevel_Id, BehavioralObjective behavioralObjective, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[ExpectedLevel.CollectionOfBehavioralObjective]";

            return this.CollectionOf<BehavioralObjective>(procedureName,
                                                    new SqlParameter("@Id",expectedLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralObjective.ToJson()));
        }
    }
}