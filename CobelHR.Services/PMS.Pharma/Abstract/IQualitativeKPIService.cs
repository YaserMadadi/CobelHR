using System.Collections.Generic;
using EssentialCore.BusinessLogic;
using EssentialCore.Tools.Result;
using CobelHR.Entities.PMS.Pharma;


namespace CobelHR.Services.PMS.Pharma.Abstract
{
    public interface IKPIService : IService<KPI>
    {
        DataResult<List<Appraise>> CollectionOfAppraise(int kpi_Id, Appraise Appraise, UserCredit userCredit);
    }
}
