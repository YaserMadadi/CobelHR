using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class UniversityHistoryService : Service<UniversityHistory>, IUniversityHistoryService
    {
        public UniversityHistoryService() : base()
        {
        }

        public override async Task<DataResult<UniversityHistory>> SaveAttached(UniversityHistory universityHistory, UserCredit userCredit)
        {
            return await universityHistory.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityTerminate>> CollectionOfUniversityTerminate(int universityHistory_Id, UniversityTerminate universityTerminate, UserCredit userCredit)
        {
            var procedureName = "[HR].[UniversityHistory.CollectionOfUniversityTerminate]";

            return this.CollectionOf<UniversityTerminate>(procedureName,
                                                    new SqlParameter("@Id",universityHistory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityTerminate.ToJson()));
        }
    }
}