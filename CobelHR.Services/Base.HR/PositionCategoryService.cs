using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.PMS;
using CobelHR.Entities.HR;
using CobelHR.Entities.PMS.Pharma;

namespace CobelHR.Services.Base.HR
{
    public class PositionCategoryService : Service<PositionCategory>, IPositionCategoryService
    {
        public PositionCategoryService() : base()
        {
        }

        public override async Task<DataResult<PositionCategory>> SaveAttached(PositionCategory positionCategory, UserCredit userCredit)
        {
            return await positionCategory.SaveAttached(userCredit);
        }

        public DataResult<List<AppraisalApproverConfig>> CollectionOfAppraisalApproverConfig(int positionCategory_Id, AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionCategory.CollectionOfAppraisalApproverConfig]";

            return this.CollectionOf<AppraisalApproverConfig>(procedureName,
                                                    new SqlParameter("@Id", positionCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", appraisalApproverConfig.ToJson()));
        }

        public DataResult<List<ConfigTargetSetting>> CollectionOfConfigTargetSetting(int positionCategory_Id, ConfigTargetSetting configTargetSetting, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionCategory.CollectionOfConfigTargetSetting]";

            return this.CollectionOf<ConfigTargetSetting>(procedureName,
                                                    new SqlParameter("@Id", positionCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", configTargetSetting.ToJson()));
        }

        public DataResult<List<Position>> CollectionOfPosition(int positionCategory_Id, Position position, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionCategory.CollectionOfPosition]";

            return this.CollectionOf<Position>(procedureName,
                                                    new SqlParameter("@Id", positionCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", position.ToJson()));
        }

        public DataResult<List<PharmaConfigTargetSetting>> CollectionOfPharmaConfigTargetSetting(int positionCategory_Id, PharmaConfigTargetSetting pharmaConfigTargetSetting, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionCategory.CollectionOfPharmaConfigTargetSetting]";

            return this.CollectionOf<PharmaConfigTargetSetting>(procedureName,
                                                    new SqlParameter("@Id", positionCategory_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", pharmaConfigTargetSetting.ToJson()));
        }

    } 
}
