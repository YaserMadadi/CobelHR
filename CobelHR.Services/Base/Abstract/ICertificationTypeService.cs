using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface ICertificationTypeService : IService<CertificationType>
    {
        DataResult<List<UniversityHistory>> CollectionOfUniversityHistory(int certificationType_Id, UniversityHistory universityHistory, UserCredit userCredit);
    }
}
