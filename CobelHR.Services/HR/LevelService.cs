using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.HR
{
    public class LevelService : Service<Level>, ILevelService
    {
        public LevelService() : base()
        {
        }

        public override async Task<DataResult<Level>> SaveAttached(Level level, UserCredit userCredit)
        {
            return await level.SaveAttached(userCredit);
        }

        public DataResult<List<ObjectiveWeightNonOperational>> CollectionOfObjectiveWeightNonOperational(int level_Id, ObjectiveWeightNonOperational objectiveWeightNonOperational, UserCredit userCredit)
        {
            var procedureName = "[HR].[Level.CollectionOfObjectiveWeightNonOperational]";

            return this.CollectionOf<ObjectiveWeightNonOperational>(procedureName,
                                                    new SqlParameter("@Id",level_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", objectiveWeightNonOperational.ToJson()));
        }

		public DataResult<List<Position>> CollectionOfPosition(int level_Id, Position position, UserCredit userCredit)
        {
            var procedureName = "[HR].[Level.CollectionOfPosition]";

            return this.CollectionOf<Position>(procedureName,
                                                    new SqlParameter("@Id",level_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", position.ToJson()));
        }
    }
}