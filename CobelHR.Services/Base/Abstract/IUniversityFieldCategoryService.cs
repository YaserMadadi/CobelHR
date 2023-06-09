using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;


namespace CobelHR.Services.Base.Abstract
{
    public interface IUniversityFieldCategoryService : IService<UniversityFieldCategory>
    {
        DataResult<List<FieldOfStudy>> CollectionOfFieldOfStudy(int universityFieldCategory_Id, FieldOfStudy fieldOfStudy, UserCredit userCredit);
    }
}
