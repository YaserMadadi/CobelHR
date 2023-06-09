using CobelHR.Services.Core.Abstract;
using CobelHR.Services.Partial.HR.Abstract;
using EssentialCore.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssentialCore.Tools.Result;
using CobelHR.Entities.Core;

namespace CobelHR.WebApiPortal.Partial.Controller
{
    [Route("api/Permission")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        IEmployeeServicePartial employeeService;

        public PermissionController(IEmployeeServicePartial employeeService)
        {
            this.employeeService = employeeService;
        }

        
    }
}
