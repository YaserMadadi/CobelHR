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
    public class EducationSystemService : Service<EducationSystem>, IEducationSystemService
    {
        public EducationSystemService() : base()
        {
        }

        public override async Task<DataResult<EducationSystem>> SaveAttached(EducationSystem educationSystem, UserCredit userCredit)
        {
            return await educationSystem.SaveAttached(userCredit);
        }

        public DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int educationSystem_Id, UniversityHistory universityHistory, UserCredit userCredit)
        {
            var procedureName = "[Base].[EducationSystem.CollectionOfUniversityHistory]";

            return this.CollectionOf<UniversityHistory>(procedureName,
                                                    new SqlParameter("@Id",educationSystem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", universityHistory.ToJson()));
        }
    }
}