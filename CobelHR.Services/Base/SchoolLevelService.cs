using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class SchoolLevelService : Service<SchoolLevel>, ISchoolLevelService
    {
        public SchoolLevelService() : base()
        {
        }

        public override async Task<DataResult<SchoolLevel>> SaveAttached(SchoolLevel schoolLevel, UserCredit userCredit)
        {
            return await schoolLevel.SaveAttached(userCredit);
        }

        public DataResult<List<SchoolHistory>> CollectionOfSchoolHistory(int schoolLevel_Id, SchoolHistory schoolHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[SchoolLevel.CollectionOfSchoolHistory]";

            return this.CollectionOf<SchoolHistory>(procedureName,
                                                    new SqlParameter("@Id",schoolLevel_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", schoolHistory.ToJson()));
        }
    }
}