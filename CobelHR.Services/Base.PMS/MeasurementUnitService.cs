using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base.PMS;
using CobelHR.Services.Base.PMS.Actions;
using CobelHR.Services.Base.PMS.Abstract;using CobelHR.Entities.PMS;


namespace CobelHR.Services.Base.PMS
{
    public class MeasurementUnitService : Service<MeasurementUnit>, IMeasurementUnitService
    {
        public MeasurementUnitService() : base()
        {
        }

        public override async Task<DataResult<MeasurementUnit>> SaveAttached(MeasurementUnit measurementUnit, UserCredit userCredit)
        {
            return await measurementUnit.SaveAttached(userCredit);
        }

        public DataResult<List<FunctionalKPI>> CollectionOfFunctionalKPI(int measurementUnit_Id, FunctionalKPI functionalKPI, UserCredit userCredit)
        {
            var procedureName = "[Base.PMS].[MeasurementUnit.CollectionOfFunctionalKPI]";

            return this.CollectionOf<FunctionalKPI>(procedureName,
                                                    new SqlParameter("@Id",measurementUnit_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", functionalKPI.ToJson()));
        }
    }
}