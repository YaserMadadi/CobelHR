using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS;


namespace CobelHR.Services.PMS.Abstract
{
    public interface IFunctionalKPIService : IService<FunctionalKPI>
    {
        DataResult<List<FunctionalAppraise>> CollectionOfFunctionalAppraise(int functionalKPI_Id, FunctionalAppraise functionalAppraise, UserCredit userCredit);

		DataResult<List<FunctionalKPIComment>> CollectionOfFunctionalKPIComment(int functionalKPI_Id, FunctionalKPIComment functionalKPIComment, UserCredit userCredit);
    }
}
