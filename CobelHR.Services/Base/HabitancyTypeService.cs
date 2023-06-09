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
    public class HabitancyTypeService : Service<HabitancyType>, IHabitancyTypeService
    {
        public HabitancyTypeService() : base()
        {
        }

        public override async Task<DataResult<HabitancyType>> SaveAttached(HabitancyType habitancyType, UserCredit userCredit)
        {
            return await habitancyType.SaveAttached(userCredit);
        }

        public DataResult<List<Habitancy>> CollectionOfHabitancy(int habitancyType_Id, Habitancy habitancy, UserCredit userCredit)
        {
            var procedureName = "[Base].[HabitancyType.CollectionOfHabitancy]";

            return this.CollectionOf<Habitancy>(procedureName,
                                                    new SqlParameter("@Id",habitancyType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", habitancy.ToJson()));
        }
    }
}