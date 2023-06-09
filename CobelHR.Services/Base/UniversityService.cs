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
    public class UniversityService : Service<University>, IUniversityService
    {
        public UniversityService() : base()
        {
        }

        public override async Task<DataResult<University>> SaveAttached(University university, UserCredit userCredit)
        {
            return await university.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int university_Id, UniversityHistory universityHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[University.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",university_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }
    }
}