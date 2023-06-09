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
    public class ExcemptionTypeService : Service<ExcemptionType>, IExcemptionTypeService
    {
        public ExcemptionTypeService() : base()
        {
        }

        public override async Task<DataResult<ExcemptionType>> SaveAttached(ExcemptionType excemptionType, UserCredit userCredit)
        {
            return await excemptionType.SaveAttached(userCredit);
        }

        public DataResult<List<MilitaryServiceExcemption>> CollectionOfMilitaryServiceExcemption(int excemptionType_Id, MilitaryServiceExcemption militaryServiceExcemption, UserCredit userCredit)
        {
            var procedureName = "[Base].[ExcemptionType.CollectionOfMilitaryServiceExcemption]";

            return this.CollectionOf<MilitaryServiceExcemption>(procedureName,
                                                    new SqlParameter("@Id",excemptionType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", militaryServiceExcemption.ToJson()));
        }
    }
}