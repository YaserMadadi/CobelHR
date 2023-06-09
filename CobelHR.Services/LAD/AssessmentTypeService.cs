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
    public class AssessmentTypeService : Service<AssessmentType>, IAssessmentTypeService
    {
        public AssessmentTypeService() : base()
        {
        }

        public override async Task<DataResult<AssessmentType>> SaveAttached(AssessmentType assessmentType, UserCredit userCredit)
        {
            return await assessmentType.SaveAttached(userCredit);
        }

        public DataResult<List<Assessment>> CollectionOfAssessment(int assessmentType_Id, Assessment assessment, UserCredit userCredit)
        {
            var procedureName = "[LAD].[AssessmentType.CollectionOfAssessment]";

            return this.CollectionOf<Assessment>(procedureName,
                                                    new SqlParameter("@Id",assessmentType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessment.ToJson()));
        }
    }
}