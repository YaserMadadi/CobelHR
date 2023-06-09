using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.XCode;
using CobelHR.Services.XCode.Actions;
using CobelHR.Services.XCode.Abstract;

namespace CobelHR.Services.XCode
{
    public class SynonymService : Service<Synonym>, ISynonymService
    {
        public SynonymService() : base()
        {
        }

        public override async Task<DataResult<Synonym>> SaveAttached(Synonym synonym, UserCredit userCredit)
        {
            return await synonym.SaveAttached(userCredit);
        }

        
    }
}