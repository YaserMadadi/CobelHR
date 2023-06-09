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
    public class FieldOfStudyService : Service<FieldOfStudy>, IFieldOfStudyService
    {
        public FieldOfStudyService() : base()
        {
        }

        public override async Task<DataResult<FieldOfStudy>> SaveAttached(FieldOfStudy fieldOfStudy, UserCredit userCredit)
        {
            return await fieldOfStudy.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int fieldOfStudy_Id, UniversityHistory universityHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[FieldOfStudy.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",fieldOfStudy_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }
    }
}