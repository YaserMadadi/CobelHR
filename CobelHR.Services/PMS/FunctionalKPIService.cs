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
    public class FunctionalKPIService : Service<FunctionalKPI>, IFunctionalKPIService
    {
        public FunctionalKPIService() : base()
        {
        }

        public override async Task<DataResult<FunctionalKPI>> SaveAttached(FunctionalKPI functionalKPI, UserCredit userCredit)
        {
            return await functionalKPI.SaveAttached(userCredit);
        }

        public DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise(int functionalKPI_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit)
        {
            var procedureName = "[PMS].[FunctionalKPI.CollectionOfFunctionalAppraise]";

            return this.CollectionOf<FunctionalAppraise>(procedureName,
                                                    new SqlParameter("@Id",functionalKPI_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalAppraise.ToJson()));
        }

		public DataResult<List<FunctionalKPIComment>> CollectionOfFunctionalKPIComment(int functionalKPI_Id, FunctionalKPIComment functionalKPIComment, UserCredit userCredit)
        {
            var procedureName = "[PMS].[FunctionalKPI.CollectionOfFunctionalKPIComment]";

            return this.CollectionOf<FunctionalKPIComment>(procedureName,
                                                    new SqlParameter("@Id",functionalKPI_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalKPIComment.ToJson()));
        }
    }
}