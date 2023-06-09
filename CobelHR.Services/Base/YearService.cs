using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base
{
    public class YearService : Service<Year>, IYearService
    {
        public YearService() : base()
        {
        }

        public override async Task<DataResult<Year>> SaveAttached(Year year, UserCredit userCredit)
        {
            return await year.SaveAttached(userCredit);
        }

        public DataResult<List<TargetSetting>> CollectionOfTargetSetting(int year_Id, TargetSetting targetSetting, UserCredit userCredit)
        {
            var procedureName = "[Base].[Year.CollectionOfTargetSetting]";

            return this.CollectionOf<TargetSetting>(procedureName,
                                                    new SqlParameter("@Id",year_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", targetSetting.ToJson()));
        }

		public DataResult<List<Vision>> CollectionOfVision(int year_Id, Vision vision, UserCredit userCredit)
        {
            var procedureName = "[Base].[Year.CollectionOfVision]";

            return this.CollectionOf<Vision>(procedureName,
                                                    new SqlParameter("@Id",year_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", vision.ToJson()));
        }

		public DataResult<List<YearQuarter>> CollectionOfYearQuarter(int year_Id, YearQuarter yearQuarter, UserCredit userCredit)
        {
            var procedureName = "[Base].[Year.CollectionOfYearQuarter]";

            return this.CollectionOf<YearQuarter>(procedureName,
                                                    new SqlParameter("@Id",year_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", yearQuarter.ToJson()));
        }
    }
}