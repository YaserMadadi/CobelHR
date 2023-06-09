using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;

namespace CobelHR.Services.Base
{
    public class ProvinceService : Service<Province>, IProvinceService
    {
        public ProvinceService() : base()
        {
        }

        public override async Task<DataResult<Province>> SaveAttached(Province province, UserCredit userCredit)
        {
            return await province.SaveAttached(userCredit);
        }

        public DataResult<List<City>> CollectionOfCity(int province_Id, City city, UserCredit userCredit)
        {
            var procedureName = "[Base].[Province.CollectionOfCity]";

            return this.CollectionOf<City>(procedureName,
                                                    new SqlParameter("@Id",province_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", city.ToJson()));
        }
    }
}