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
    public class PassportService : Service<Passport>, IPassportService
    {
        public PassportService() : base()
        {
        }

        public override async Task<DataResult<Passport>> SaveAttached(Passport passport, UserCredit userCredit)
        {
            return await passport.SaveAttached(userCredit);
        }

        
    }
}