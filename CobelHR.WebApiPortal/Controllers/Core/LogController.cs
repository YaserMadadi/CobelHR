using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Core.Abstract;
using CobelHR.Entities.Core;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Core
{
    [Route("api/Core")]
    public class LogController : BaseController
    {
        public LogController(ILogService logService)
        {
            this.logService = logService;
        }

        private ILogService logService { get; set; }

        [HttpGet]
        [Route("Log/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.logService.RetrieveById(id, Log.Informer, this.UserCredit);

			return result.ToActionResult<Log>();
        }

        [HttpPost]
        [Route("Log/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.logService.RetrieveAll(Log.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Log>();
        }
            

        
        [HttpPost]
        [Route("Log/Save")]
        public async Task<IActionResult> Save([FromBody] Log log)
        {
            var result = await this.logService.Save(log, this.UserCredit);

			return result.ToActionResult<Log>();
        }

        
        [HttpPost]
        [Route("Log/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Log log)
        {
            var result = await this.logService.SaveAttached(log, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Log/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Log> logList)
        {
            var result = await this.logService.SaveBulk(logList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Log/Seek")]
        public async Task<IActionResult> Seek([FromBody] Log log)
        {
            var result = await this.logService.Seek(log, this.UserCredit);

			return result.ToActionResult<Log>();
        }

        [HttpGet]
        [Route("Log/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.logService.SeekByValue(seekValue, Log.Informer, this.UserCredit);

			return result.ToActionResult<Log>();
        }

        [HttpPost]
        [Route("Log/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Log log)
        {
            var result = await this.logService.Delete(log, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}