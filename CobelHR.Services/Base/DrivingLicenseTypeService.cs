using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EssentialCore.Tools.Security.Entities;
using EssentialCore.Tools.Result;
using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using CobelHR.Entities.Base;
using CobelHR.Services.Base.Actions;
using CobelHR.Services.Base.Abstract;using CobelHR.Entities.HR;


namespace CobelHR.Services.Base
{
    public class DrivingLicenseTypeService : Service<DrivingLicenseType>, IDrivingLicenseTypeService
    {
        public DrivingLicenseTypeService() : base()
        {
        }

        public override async Task<DataResult<DrivingLicenseType>> SaveAttached(DrivingLicenseType drivingLicenseType, UserCredit userCredit)
        {
            return await drivingLicenseType.SaveAttached(userCredit);
        }

        public DataResult<List<PersonDrivingLicense>> CollectionOfPersonDrivingLicense(int drivingLicenseType_Id, PersonDrivingLicense personDrivingLicense, UserCredit userCredit)
        {
            var procedureName = "[Base].[DrivingLicenseType.CollectionOfPersonDrivingLicense]";

            return this.CollectionOf<PersonDrivingLicense>(procedureName,
                                                    new SqlParameter("@Id",drivingLicenseType_Id),
                                                    //new SqlParameter("@User_Id", userCredit.Person_Id), 
                                                    new SqlParameter("@jsonValue", personDrivingLicense.ToJson()));
        }
    }
}