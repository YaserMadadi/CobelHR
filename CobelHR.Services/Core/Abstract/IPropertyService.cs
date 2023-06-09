using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface IPropertyService : IService<Property>
    {
        DataResult<List<PropertyOption>> CollectionOfPropertyOption(int property_Id, PropertyOption propertyOption, UserCredit userCredit);
    }
}
