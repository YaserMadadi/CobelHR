using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.LAD;


namespace CobelHR.Services.Base
{
    public class YearQuarterService : Service<YearQuarter>, IYearQuarterService
    {
        public YearQuarterService() : base()
        {
        }

        public override async Task<DataResult<YearQuarter>> SaveAttached(YearQuarter yearQuarter, UserCredit userCredit)
        {
            return await yearQuarter.SaveAttached(userCredit);
        }

        public DataResult<List<AssessmentTraining>> CollectionOfAssessmentTraining_DeadLine(int yearQuarter_Id, AssessmentTraining assessmentTraining, UserCredit userCredit)
        {
            var procedureName = "[Base].[YearQuarter(DeadLine).CollectionOfAssessmentTraining]";

            return this.CollectionOf<AssessmentTraining>(procedureName,
                                                    new SqlParameter("@Id",yearQuarter_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessmentTraining.ToJson()));
        }
    }
}