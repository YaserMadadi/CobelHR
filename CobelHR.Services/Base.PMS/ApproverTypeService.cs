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
    public class ApproverTypeService : Service<ApproverType>, IApproverTypeService
    {
        public ApproverTypeService() : base()
        {
        }

        public override async Task<DataResult<ApproverType>> SaveAttached(ApproverType approverType, UserCredit userCredit)
        {
            return await approverType.SaveAttached(userCredit);
        }

        public DataResult<List<AppraisalApproverConfig>> CollectionOfAppraisalApproverConfig(int approverType_Id, AppraisalApproverConfig appraisalApproverConfig, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[ApproverType.CollectionOfAppraisalApproverConfig]";

            return this.CollectionOf<AppraisalApproverConfig>(procedureName,
                                                    new SqlParameter("@Id",approverType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", appraisalApproverConfig.ToJson()));
        }
    }
}