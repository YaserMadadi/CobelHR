using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;


namespace CobelHR.Services.Core.Abstract
{
    public interface ISubSystemService : IService<SubSystem>
    {
        DataResult<List<Menu>> CollectionOfMenu(int subSystem_Id, Menu menu, UserCredit userCredit);
    }
}
