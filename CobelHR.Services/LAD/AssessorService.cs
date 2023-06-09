using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.LAD;
using CobelHR.Services.LAD.Actions;
using CobelHR.Services.LAD.Abstract;

namespace CobelHR.Services.LAD
{
    public class AssessorService : Service<Assessor>, IAssessorService
    {
        public AssessorService() : base()
        {
        }

        public override async Task<DataResult<Assessor>> SaveAttached(Assessor assessor, UserCredit userCredit)
        {
            return await assessor.SaveAttached(userCredit);
        }

        public DataResult<List<Assessment>> CollectionOfAssessment(int assessor_Id, Assessment assessment, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessor.CollectionOfAssessment]";

            return this.CollectionOf<Assessment>(procedureName,
                                                    new SqlParameter("@Id",assessor_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessment.ToJson()));
        }

		public DataResult<List<AssessorConnectionLine>> CollectionOfAssessorConnectionLine(int assessor_Id, AssessorConnectionLine assessorConnectionLine, UserCredit userCredit)
        {
            var procedureName = "[LAD].[Assessor.CollectionOfAssessorConnectionLine]";

            return this.CollectionOf<AssessorConnectionLine>(procedureName,
                                                    new SqlParameter("@Id",assessor_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessorConnectionLine.ToJson()));
        }
    }
}