using CobelHR.Entities.Core;
using CobelHR.Services.Partial.HR.Abstract;
using EssentialCore.Tools.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using CobelHR.Entities.PMS;

namespace CobelHR.WebApiPortal.Partial.Controller.HR
{
    [Route("api/HR")]
    [ApiController]
    public class OrgChartController : ControllerBase // BaseController
    {
        IOrgChartService orgChartService;

        public OrgChartController(IOrgChartService orgChartService)
        {
            this.orgChartService = orgChartService;
        }

        [HttpGet]
        [Route("OrgChart/Load/{id:int}")]
        public IActionResult LoadTargetSetting(int id)
        {
            var result = this.orgChartService.LoadOrgChart(id);

            //result.Data

            return new OkObjectResult(result.Data);
        }
    }
}
