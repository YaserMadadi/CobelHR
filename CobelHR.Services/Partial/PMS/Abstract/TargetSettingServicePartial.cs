using CobelHR.Entities.PMS;
using CobelHR.Services.PMS.Abstract;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobelHR.Services.Partial.PMS.Abstract
{
    public interface ITargetSettingServicePartial : ITargetSettingService
    {
        DataResult<List<Vision>> CollectionOfVision(int taregtSetting_Id, Vision vision);
        
        DataResult<List<FunctionalObjective>> CollectionOfParentalFunctionalObjective(int taregtSetting_Id);
    }
}
