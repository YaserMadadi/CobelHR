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
    public class FunctionalObjectiveService : Service<FunctionalObjective>, IFunctionalObjectiveService
    {
        public FunctionalObjectiveService() : base()
        {
        }

        public override async Task<DataResult<FunctionalObjective>> SaveAttached(FunctionalObjective functionalObjective, UserCredit userCredit)
        {
            return await functionalObjective.SaveAttached(userCredit);
        }

        public DataResult<List<FunctionalKPI>> CollectionOfFunctionalKPI(int functionalObjective_Id, FunctionalKPI functionalKPI, UserCredit userCredit)
        {
            var procedureName = "[PMS].[FunctionalObjective.CollectionOfFunctionalKPI]";

            return this.CollectionOf<FunctionalKPI>(procedureName,
                                                    new SqlParameter("@Id",functionalObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalKPI.ToJson()));
        }

		public DataResult<List<FunctionalObjective>> CollectionOfFunctionalObjective_ParentalFunctionalObjective(int functionalObjective_Id, FunctionalObjective functionalObjective, UserCredit userCredit)
        {
            var procedureName = "[PMS].[FunctionalObjective(ParentalFunctionalObjective).CollectionOfFunctionalObjective]";

            return this.CollectionOf<FunctionalObjective>(procedureName,
                                                    new SqlParameter("@Id",functionalObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalObjective.ToJson()));
        }

		public DataResult<List<FunctionalObjectiveComment>> CollectionOfFunctionalObjectiveComment(int functionalObjective_Id, FunctionalObjectiveComment functionalObjectiveComment, UserCredit userCredit)
        {
            var procedureName = "[PMS].[FunctionalObjective.CollectionOfFunctionalObjectiveComment]";

            return this.CollectionOf<FunctionalObjectiveComment>(procedureName,
                                                    new SqlParameter("@Id",functionalObjective_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalObjectiveComment.ToJson()));
        }
    }
}