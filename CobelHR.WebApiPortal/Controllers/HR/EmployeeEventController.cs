using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.HR.Abstract;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.HR
{
    [Route("api/HR")]
    public class EmployeeEventController : BaseController
    {
        public EmployeeEventController(IEmployeeEventService employeeEventService)
        {
            this.employeeEventService = employeeEventService;
        }

        private IEmployeeEventService employeeEventService { get; set; }

        [HttpGet]
        [Route("EmployeeEvent/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.employeeEventService.RetrieveById(id, EmployeeEvent.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeEvent>();
        }

        [HttpPost]
        [Route("EmployeeEvent/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.employeeEventService.RetrieveAll(EmployeeEvent.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EmployeeEvent>();
        }
            

        
        [HttpPost]
        [Route("EmployeeEvent/Save")]
        public async Task<IActionResult> Save([FromBody] EmployeeEvent employeeEvent)
        {
            var result = await this.employeeEventService.Save(employeeEvent, this.UserCredit);

			return result.ToActionResult<EmployeeEvent>();
        }

        
        [HttpPost]
        [Route("EmployeeEvent/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EmployeeEvent employeeEvent)
        {
            var result = await this.employeeEventService.SaveAttached(employeeEvent, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeEvent/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EmployeeEvent> employeeEventList)
        {
            var result = await this.employeeEventService.SaveBulk(employeeEventList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeEvent/Seek")]
        public async Task<IActionResult> Seek([FromBody] EmployeeEvent employeeEvent)
        {
            var result = await this.employeeEventService.Seek(employeeEvent, this.UserCredit);

			return result.ToActionResult<EmployeeEvent>();
        }

        [HttpGet]
        [Route("EmployeeEvent/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.employeeEventService.SeekByValue(seekValue, EmployeeEvent.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeEvent>();
        }

        [HttpPost]
        [Route("EmployeeEvent/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeEvent employeeEvent)
        {
            var result = await this.employeeEventService.Delete(employeeEvent, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}