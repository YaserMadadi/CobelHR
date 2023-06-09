using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS
{
    public class AppraiseTypeService : Service<AppraiseType>, IAppraiseTypeService
    {
        public AppraiseTypeService() : base()
        {
        }

        public override async Task<DataResult<AppraiseType>> SaveAttached(AppraiseType appraiseType, UserCredit userCredit)
        {
            return await appraiseType.SaveAttached(userCredit);
        }

        public DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int appraiseType_Id, AppraiseResult appraiseResult, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[AppraiseType.CollectionOfAppraiseResult]";

            return this.CollectionOf<AppraiseResult>(procedureName,
                                                    new SqlParameter("@Id",appraiseType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", appraiseResult.ToJson()));
        }

		public DataResult<List<BehavioralAppraise>> CollectionOfBehavioralAppraise(int appraiseType_Id, BehavioralAppraise behavioralAppraise, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[AppraiseType.CollectionOfBehavioralAppraise]";

            return this.CollectionOf<BehavioralAppraise>(procedureName,
                                                    new SqlParameter("@Id",appraiseType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralAppraise.ToJson()));
        }

		public DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise(int appraiseType_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[AppraiseType.CollectionOfFunctionalAppraise]";

            return this.CollectionOf<FunctionalAppraise>(procedureName,
                                                    new SqlParameter("@Id",appraiseType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalAppraise.ToJson()));
        }

		public DataResult<List<QualitativeAppraise>> CollectionOfQualitativeAppraise(int appraiseType_Id, QualitativeAppraise qualitativeAppraise, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[AppraiseType.CollectionOfQualitativeAppraise]";

            return this.CollectionOf<QualitativeAppraise>(procedureName,
                                                    new SqlParameter("@Id",appraiseType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", qualitativeAppraise.ToJson()));
        }
    }
}