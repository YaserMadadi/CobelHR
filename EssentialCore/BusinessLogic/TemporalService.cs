using EssentialCore.DataAccess;
using EssentialCore.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.BusinessLogic
{
    public class TemporalService<T> : Service<T>, ITemporalService<T> where T : IEntityBase
    {
        public TemporalService()
        {

        }

        public async Task<DataResult<T>> RetrieveById(int id, DateTime time, Info info, UserCredit userCredit)
        {
            //TODO: CheckPermission
            //                                                                   RetrieveById
            var command = UserClass.CreateCommand($"[{info.Schema}].[{info.Name}.RetrieveById]",
                                                                        new SqlParameter("@Id", id),
                                                                        new SqlParameter("@Time", time));
                                                                        //new SqlParameter("@User_Id", userCredit.Person_Id));

            IDataResult<string> result = await command.ExecuteDataResult();

            if (!result.IsSucceeded)

                return new ErrorDataResult<T>(result.Id, result.Message);

            T entity = result.Data.Deserialize<T>(JsonType.Single);

            if (!EntityBase.Confirm(entity))

                return new ErrorDataResult<T>(-1, "Entity has not Found!");

            return new SuccessfulDataResult<T>(entity);
        }
    }
}
