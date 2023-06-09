using CobelHR.Entities.Core;
using CobelHR.Services.Core;
using CobelHR.Services.Partial.Core.Abstract;
using EssentialCore.DataAccess;
using EssentialCore.Entities;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.Core
{
    public class LogServicePartial : LogService, ILogServicePartial
    {
        public async Task<DataResult<List<Log>>> LoadLog(string entityName, int recordId, UserCredit userCredit)
        {
            return await this.Seek(new Log() { EntityName = entityName, RecordID = recordId }, userCredit);
        }
    }
}
