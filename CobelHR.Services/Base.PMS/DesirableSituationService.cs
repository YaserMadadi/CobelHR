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
    public class DesirableSituationService : Service<DesirableSituation>, IDesirableSituationService
    {
        public DesirableSituationService() : base()
        {
        }

        public override async Task<DataResult<DesirableSituation>> SaveAttached(DesirableSituation desirableSituation, UserCredit userCredit)
        {
            return await desirableSituation.SaveAttached(userCredit);
        }

        public DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int desirableSituation_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[DesirableSituation.CollectionOfIndividualDevelopmentPlan]";

            return this.CollectionOf<IndividualDevelopmentPlan>(procedureName,
                                                    new SqlParameter("@Id",desirableSituation_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }
    }
}