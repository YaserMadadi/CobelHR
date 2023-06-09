using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.PMS;using CobelHR.Entities.PMS;



namespace CobelHR.Services.Base.PMS.Abstract
{
    public interface IMeasurementUnitService : IService<MeasurementUnit>
    {
        DataResult<List<FunctionalKPI>> CollectionOfFunctionalKPI(int measurementUnit_Id, FunctionalKPI functionalKPI, UserCredit userCredit);
    }
}
