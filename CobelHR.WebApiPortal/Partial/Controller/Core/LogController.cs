using CobelHR.Entities.Core;
using CobelHR.Services.Partial.Core.Abstract;
using EssentialCore.Controllers;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobelHR.WebApiPortal.Partial.Controller.Core
{
    [Route("api/Partial/Core/Log")]
    public class LogController : BaseController
    {
        private ILogServicePartial logService;

        public LogController(ILogServicePartial logService)
        {
            this.logService = logService;
        }

        [HttpGet]
        [Route("Load/{entityName}/{recordId}")]
        public async Task<IActionResult> Load([FromRoute] string entityName, [FromRoute] int recordId)
        {
            return (await this.logService.LoadLog(entityName, recordId, this.UserCredit)).ToActionResult<Log>();
        }

    }
}
