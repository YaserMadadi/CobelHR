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
    public class InclusiveTypeService : Service<InclusiveType>, IInclusiveTypeService
    {
        public InclusiveTypeService() : base()
        {
        }

        public override async Task<DataResult<InclusiveType>> SaveAttached(InclusiveType inclusiveType, UserCredit userCredit)
        {
            return await inclusiveType.SaveAttached(userCredit);
        }

        public DataResult<List<MilitaryServiceInclusive>> CollectionOfMilitaryServiceInclusive(int inclusiveType_Id, MilitaryServiceInclusive militaryServiceInclusive, UserCredit userCredit)
        {
            var procedureName = "[Base].[InclusiveType.CollectionOfMilitaryServiceInclusive]";

            return this.CollectionOf<MilitaryServiceInclusive>(procedureName,
                                                    new SqlParameter("@Id",inclusiveType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", militaryServiceInclusive.ToJson()));
        }
    }
}