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
    public class MilitaryServiceService : Service<MilitaryService>, IMilitaryServiceService
    {
        public MilitaryServiceService() : base()
        {
        }

        public override async Task<DataResult<MilitaryService>> SaveAttached(MilitaryService militaryService, UserCredit userCredit)
        {
            return await militaryService.SaveAttached(userCredit);
        }

        public DataResult<List<MilitaryServiceExcemption>> CollectionOfMilitaryServiceExcemption(int militaryService_Id, MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit)
        {
            var procedureName = "[HR].[MilitaryService.CollectionOfMilitaryServiceExcemption]";

            return this.CollectionOf<MilitaryServiceExcemption>(procedureName,
                                                    new SqlParameter("@Id",militaryService_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", militaryServiceExcemption.ToJson()));
        }

		public DataResult<List<MilitaryServiceInclusive>> CollectionOfMilitaryServiceInclusive(int militaryService_Id, MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit)
        {
            var procedureName = "[HR].[MilitaryService.CollectionOfMilitaryServiceInclusive]";

            return this.CollectionOf<MilitaryServiceInclusive>(procedureName,
                                                    new SqlParameter("@Id",militaryService_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", militaryServiceInclusive.ToJson()));
        }
    }
}