using CobelHR.Entities;
using EssentialCore.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobelHR.WebApiPortal.Controllers
{
    [Route("api")]
    [ApiController]
    [AllowAnonymous]
    public class CheckController : ControllerBase
    {
        [HttpGet]
        [Route("Check")]
        public ActionResult Check()
        {
            return Ok(new Check().ToString());
        }

        [HttpGet]
        [Route("CheckIP")]
        public ActionResult CheckIP()
        {
            return Ok(new CheckConnection().ToString());
        }


        [HttpGet]
        [Route("CheckConnection")]
        public ActionResult CheckConnection()
        {
            return Ok(ConnectionManager.CheckConnection());
        }


    }
}
