using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.Abstract
{
    public interface IFieldCategoryService : IService<FieldCategory>
    {
        DataResult<List<PersonCertificate>> CollectionOfPersonCertificate(int fieldCategory_Id, PersonCertificate personCertificate, UserCredit userCredit);
    }
}
