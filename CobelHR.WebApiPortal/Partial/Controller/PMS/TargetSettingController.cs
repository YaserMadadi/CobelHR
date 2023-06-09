using CobelHR.Services.Partial.PMS.Abstract;
using EssentialCore.Controllers;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobelHR.WebApiPortal.Partial.Controller.PMS
{
    [Route("api/PMS")]
    [ApiController]
    public class TargetSettingController : BaseController
    {
        ITargetSettingServicePartial targetSettingServicePartial;

        public TargetSettingController(ITargetSettingServicePartial targetSettingServicePartial)
        {
            this.targetSettingServicePartial = targetSettingServicePartial;
        }

        [HttpGet]
        [Route("TargetSetting/{targetSetting_id:int}/Vision")]
        public IActionResult LoadTargetSetting(int targetSetting_id)
        {
            return this.targetSettingServicePartial.CollectionOfVision(targetSetting_id, null).ToActionResult();
        }
        
        [HttpGet]
        [Route("TargetSetting/{targetSetting_id:int}/CollectionOfParentalFunctionalObjective")]
        public IActionResult CollectionOfParentalFunctionalObjective(int targetSetting_id)
        {
            return this.targetSettingServicePartial.CollectionOfParentalFunctionalObjective(targetSetting_id).ToActionResult();
        }
    }
}
