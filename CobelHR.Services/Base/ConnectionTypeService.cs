using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.LAD;
using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class ConnectionTypeService : Service<ConnectionType>, IConnectionTypeService
    {
        public ConnectionTypeService() : base()
        {
        }

        public override async Task<DataResult<ConnectionType>> SaveAttached(ConnectionType connectionType, UserCredit userCredit)
        {
            return await connectionType.SaveAttached(userCredit);
        }

        public DataResult<List<AssessorConnectionLine>> CollectionOfAssessorConnectionLine(int connectionType_Id, AssessorConnectionLine assessorConnectionLine, UserCredit userCredit)
        {
            var procedureName = "[Base].[ConnectionType.CollectionOfAssessorConnectionLine]";

            return this.CollectionOf<AssessorConnectionLine>(procedureName,
                                                    new SqlParameter("@Id",connectionType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", assessorConnectionLine.ToJson()));
        }

		public DataResult<List<CoachConnectionLine>> CollectionOfCoachConnectionLine(int connectionType_Id, CoachConnectionLine coachConnectionLine, UserCredit userCredit)
        {
            var procedureName = "[Base].[ConnectionType.CollectionOfCoachConnectionLine]";

            return this.CollectionOf<CoachConnectionLine>(procedureName,
                                                    new SqlParameter("@Id",connectionType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", coachConnectionLine.ToJson()));
        }

		public DataResult<List<PersonConnection>> CollectionOfPersonConnection(int connectionType_Id, PersonConnection personConnection, UserCredit userCredit)
        {
            var procedureName = "[Base].[ConnectionType.CollectionOfPersonConnection]";

            return this.CollectionOf<PersonConnection>(procedureName,
                                                    new SqlParameter("@Id",connectionType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", personConnection.ToJson()));
        }
    }
}