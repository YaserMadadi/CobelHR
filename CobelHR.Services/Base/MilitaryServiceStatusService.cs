using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class MilitaryServiceStatusService : Service<MilitaryServiceStatus>, IMilitaryServiceStatusService
    {
        public MilitaryServiceStatusService() : base()
        {
        }

        public override async Task<DataResult<MilitaryServiceStatus>> SaveAttached(MilitaryServiceStatus militaryServiceStatus, UserCredit userCredit)
        {
            return await militaryServiceStatus.SaveAttached(userCredit);
        }

        public DataResult<List<MilitaryService>> CollectionOfMilitaryService(int militaryServiceStatus_Id, MilitaryService militaryService, UserCredit userCredit)
        {
            var procedureName = "[Base].[MilitaryServiceStatus.CollectionOfMilitaryService]";

            return this.CollectionOf<MilitaryService>(procedureName,
                                                    new SqlParameter("@Id",militaryServiceStatus_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", militaryService.ToJson()));
        }
    }
}