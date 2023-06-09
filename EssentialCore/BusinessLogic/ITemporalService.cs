using EssentialCore.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.BusinessLogic
{
    public interface ITemporalService<T> : IService<T> where T : IEntityBase
    {
        public Task<DataResult<T>> RetrieveById(int id, DateTime time, Info info, UserCredit userCredit);
    }
}
