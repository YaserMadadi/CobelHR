using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IDrivingLicenseTypeService : IService<DrivingLicenseType>
    {
        DataResult<List<PersonDrivingLicense>> CollectionOfPersonDrivingLicense(int drivingLicenseType_Id, PersonDrivingLicense personDrivingLicense, UserCredit userCredit);
    }
}
