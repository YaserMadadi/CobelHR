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
    public class PositionAssignmentService : Service<PositionAssignment>, IPositionAssignmentService
    {
        public PositionAssignmentService() : base()
        {
        }

        public override async Task<DataResult<PositionAssignment>> SaveAttached(PositionAssignment positionAssignment, UserCredit userCredit)
        {
            return await positionAssignment.SaveAttached(userCredit);
        }

        public DataResult<List<PositionAssignmentRepeal>> CollectionOfPositionAssignmentRepeal(int positionAssignment_Id, PositionAssignmentRepeal positionAssignmentRepeal, UserCredit userCredit)
        {
            var procedureName = "[HR].[PositionAssignment.CollectionOfPositionAssignmentRepeal]";

            return this.CollectionOf<PositionAssignmentRepeal>(procedureName,
                                                    new SqlParameter("@Id",positionAssignment_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", positionAssignmentRepeal.ToJson()));
        }
    }
}