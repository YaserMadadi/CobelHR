using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.PMS.Pharma;
using CobelHR.Services.PMS.Pharma.Actions;
using CobelHR.Services.PMS.Pharma.Abstract;

namespace CobelHR.Services.PMS.Pharma
{
    public class ObjectiveTypeService : Service<ObjectiveType>, IObjectiveTypeService
    {
        public ObjectiveTypeService() : base()
        {
        }

        public override async Task<DataResult<ObjectiveType>> SaveAttached(ObjectiveType objectiveType, UserCredit userCredit)
        {
            return await objectiveType.SaveAttached(userCredit);
        }

        public DataResult<List<Objective>> CollectionOfObjective(int objectiveType_Id, Objective objective, UserCredit userCredit)
        {
            var procedureName = "[PMS.Pharma].[ObjectiveType.CollectionOfObjective]";

            return this.CollectionOf<Objective>(procedureName,
                                                    new SqlParameter("@Id",objectiveType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", objective.ToJson()));
        }
    }
}