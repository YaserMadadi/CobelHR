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
    public class ApprovementTypeService : Service<ApprovementType>, IApprovementTypeService
    {
        public ApprovementTypeService() : base()
        {
        }

        public override async Task<DataResult<ApprovementType>> SaveAttached(ApprovementType approvementType, UserCredit userCredit)
        {
            return await approvementType.SaveAttached(userCredit);
        }

        public DataResult<List<VisionApproved>> CollectionOfVisionApproved(int approvementType_Id, VisionApproved visionApproved, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[ApprovementType.CollectionOfVisionApproved]";

            return this.CollectionOf<VisionApproved>(procedureName,
                                                    new SqlParameter("@Id",approvementType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", visionApproved.ToJson()));
        }
    }
}