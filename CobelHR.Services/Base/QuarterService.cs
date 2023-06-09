using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;

namespace CobelHR.Services.Base
{
    public class QuarterService : Service<Quarter>, IQuarterService
    {
        public QuarterService() : base()
        {
        }

        public override async Task<DataResult<Quarter>> SaveAttached(Quarter quarter, UserCredit userCredit)
        {
            return await quarter.SaveAttached(userCredit);
        }

        public DataResult<List<YearQuarter>> CollectionOfYearQuarter(int quarter_Id, YearQuarter yearQuarter, UserCredit userCredit)
        {
            var procedureName = "[Base].[Quarter.CollectionOfYearQuarter]";

            return this.CollectionOf<YearQuarter>(procedureName,
                                                    new SqlParameter("@Id",quarter_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", yearQuarter.ToJson()));
        }
    }
}