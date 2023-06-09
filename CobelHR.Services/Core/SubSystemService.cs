using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Core;
using CobelHR.Services.Core.Actions;
using CobelHR.Services.Core.Abstract;

namespace CobelHR.Services.Core
{
    public class SubSystemService : Service<SubSystem>, ISubSystemService
    {
        public SubSystemService() : base()
        {
        }

        public override async Task<DataResult<SubSystem>> SaveAttached(SubSystem subSystem, UserCredit userCredit)
        {
            return await subSystem.SaveAttached(userCredit);
        }

        public DataResult<List<Menu>> CollectionOfMenu(int subSystem_Id, Menu menu, UserCredit userCredit)
        {
            var procedureName = "[Core].[SubSystem.CollectionOfMenu]";

            return this.CollectionOf<Menu>(procedureName,
                                                    new SqlParameter("@Id",subSystem_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", menu.ToJson()));
        }
    }
}