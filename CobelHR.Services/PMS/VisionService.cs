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

namespace CobelHR.Services.PMS
{
    public class VisionService : Service<Vision>, IVisionService
    {
        public VisionService() : base()
        {
        }

        public override async Task<DataResult<Vision>> SaveAttached(Vision vision, UserCredit userCredit)
        {
            return await vision.SaveAttached(userCredit);
        }

        public DataResult<List<IndividualDevelopmentPlan>> CollectionOfIndividualDevelopmentPlan(int vision_Id, IndividualDevelopmentPlan individualDevelopmentPlan, UserCredit userCredit)
        {
            var procedureName = "[PMS].[Vision.CollectionOfIndividualDevelopmentPlan]";

            return this.CollectionOf<IndividualDevelopmentPlan>(procedureName,
                                                    new SqlParameter("@Id",vision_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", individualDevelopmentPlan.ToJson()));
        }

		public DataResult<List<VisionApproved>> CollectionOfVisionApproved(int vision_Id, VisionApproved visionApproved, UserCredit userCredit)
        {
            var procedureName = "[PMS].[Vision.CollectionOfVisionApproved]";

            return this.CollectionOf<VisionApproved>(procedureName,
                                                    new SqlParameter("@Id",vision_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", visionApproved.ToJson()));
        }

		public DataResult<List<VisionComment>> CollectionOfVisionComment(int vision_Id, VisionComment visionComment, UserCredit userCredit)
        {
            var procedureName = "[PMS].[Vision.CollectionOfVisionComment]";

            return this.CollectionOf<VisionComment>(procedureName,
                                                    new SqlParameter("@Id",vision_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", visionComment.ToJson()));
        }
    }
}