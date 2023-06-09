using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.HR;
using CobelHR.Services.Base.HR.Actions;
using CobelHR.Services.Base.HR.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base.HR
{
    public class PositionDivisionService : Service<PositionDivision>, IPositionDivisionService
    {
        public PositionDivisionService() : base()
        {
        }

        public override async Task<DataResult<PositionDivision>> SaveAttached(PositionDivision positionDivision, UserCredit userCredit)
        {
            return await positionDivision.SaveAttached(userCredit);
        }

        public DataResult<List<Position>> CollectionOfPosition(int positionDivision_Id, Position position, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionDivision.CollectionOfPosition]";

            return this.CollectionOf<Position>(procedureName,
                                                    new SqlParameter("@Id",positionDivision_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", position.ToJson()));
        }

		public DataResult<List<Unit>> CollectionOfUnit(int positionDivision_Id, Unit unit, UserCredit userCredit)
        {
            var procedureName = "[Base.HR].[PositionDivision.CollectionOfUnit]";

            return this.CollectionOf<Unit>(procedureName,
                                                    new SqlParameter("@Id",positionDivision_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", unit.ToJson()));
        }
    }
}