using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Base.HR;using CobelHR.Entities.HR;



namespace CobelHR.Services.Base.HR.Abstract
{
    public interface IRelativeTypeService : IService<RelativeType>
    {
        DataResult<List<Relative>> CollectionOfRelative_RelationType(int relativeType_Id, Relative relative, UserCredit userCredit);
    }
}
