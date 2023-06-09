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
    public class VisionCommentService : Service<VisionComment>, IVisionCommentService
    {
        public VisionCommentService() : base()
        {
        }

        public override async Task<DataResult<VisionComment>> SaveAttached(VisionComment visionComment, UserCredit userCredit)
        {
            return await visionComment.SaveAttached(userCredit);
        }

        
    }
}