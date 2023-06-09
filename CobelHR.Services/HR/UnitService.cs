using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.HR;
using CobelHR.Services.HR.Actions;
using CobelHR.Services.HR.Abstract;

namespace CobelHR.Services.HR
{
    public class UnitService : Service<Unit>, IUnitService
    {
        public UnitService() : base()
        {
        }

        public override async Task<DataResult<Unit>> SaveAttached(Unit unit, UserCredit userCredit)
        {
            return await unit.SaveAttached(userCredit);
        }

        public DataResult<List<Position>> CollectionOfPosition(int unit_Id, Position position, UserCredit userCredit)
        {
            var procedureName = "[HR].[Unit.CollectionOfPosition]";

            return this.CollectionOf<Position>(procedureName,
                                                    new SqlParameter("@Id",unit_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", position.ToJson()));
        }
    }
}