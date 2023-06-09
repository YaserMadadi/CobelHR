using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;


namespace CobelHR.Services.Base.Abstract
{
    public interface IProvinceService : IService<Province>
    {
        DataResult<List<City>> CollectionOfCity(int province_Id, City city, UserCredit userCredit);
    }
}
