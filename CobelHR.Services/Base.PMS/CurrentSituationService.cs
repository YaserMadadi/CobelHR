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
    public class CurrentSituationService : Service<CurrentSituation>, ICurrentSituationService
    {
        public CurrentSituationService() : base()
        {
        }

        public override async Task<DataResult<CurrentSituation>> SaveAttached(CurrentSituation currentSituation, UserCredit userCredit)
        {
            return await currentSituation.SaveAttached(userCredit);
        }

        public DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int currentSituation_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[CurrentSituation.CollectionOfIndividualDevelopmentPlan]";

            return this.CollectionOf<IndividualDevelopmentPlan>(procedureName,
                                                    new SqlParameter("@Id",currentSituation_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }
    }
}