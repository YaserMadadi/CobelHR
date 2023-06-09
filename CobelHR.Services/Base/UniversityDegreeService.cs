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
    public class UniversityDegreeService : Service<UniversityDegree>, IUniversityDegreeService
    {
        public UniversityDegreeService() : base()
        {
        }

        public override async Task<DataResult<UniversityDegree>> SaveAttached(UniversityDegree universityDegree, UserCredit userCredit)
        {
            return await universityDegree.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int universityDegree_Id, UniversityHistory universityHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[UniversityDegree.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",universityDegree_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }
    }
}