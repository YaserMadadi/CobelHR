using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Actions;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.Services.PMS
{
    public class TargetSettingService : Service<TargetSetting>, ITargetSettingService
    {
        public TargetSettingService() : base()
        {
        }

        public override async Task<DataResult<TargetSetting>> SaveAttached(TargetSetting targetSetting, UserCredit userCredit)
        {
            return await targetSetting.SaveAttached(userCredit);
        }

        public DataResult<List<AppraiseResult>> CollectionOfAppraiseResult(int targetSetting_Id, AppraiseResult appraiseResult, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfAppraiseResult]";

            return this.CollectionOf<AppraiseResult>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", appraiseResult.ToJson()));
        }

		public DataResult<List<BehavioralObjective>> CollectionOfBehavioralObjective(int targetSetting_Id, BehavioralObjective behavioralObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfBehavioralObjective]";

            return this.CollectionOf<BehavioralObjective>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", behavioralObjective.ToJson()));
        }

		public DataResult<List<FinalAppraise>> CollectionOfFinalAppraise(int targetSetting_Id, FinalAppraise finalAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfFinalAppraise]";

            return this.CollectionOf<FinalAppraise>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", finalAppraise.ToJson()));
        }

		public DataResult<List<FunctionalObjective>> CollectionOfFunctionalObjective(int targetSetting_Id, FunctionalObjective functionalObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfFunctionalObjective]";

            return this.CollectionOf<FunctionalObjective>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalObjective.ToJson()));
        }

		public DataResult<List<QualitativeObjective>> CollectionOfQualitativeObjective(int targetSetting_Id, QualitativeObjective qualitativeObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfQualitativeObjective]";

            return this.CollectionOf<QualitativeObjective>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", qualitativeObjective.ToJson()));
        }

		public DataResult<List<QuantitativeAppraise>> CollectionOfQuantitativeAppraise(int targetSetting_Id, QuantitativeAppraise quantitativeAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfQuantitativeAppraise]";

            return this.CollectionOf<QuantitativeAppraise>(procedureName,
                                                    new SqlParameter("@Id",targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", quantitativeAppraise.ToJson()));
        }

        public DataResult<List<Objective>> CollectionOfObjective(int targetSetting_Id, Objective objective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[TargetSetting.CollectionOfObjective]";

            return this.CollectionOf<Objective>(procedureName,
                                                    new SqlParameter("@Id", targetSetting_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", objective.ToJson()));
        }
    }
}