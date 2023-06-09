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
    public class EmployeeNotificationController : BaseController
    {
        public EmployeeNotificationController(IEmployeeNotificationService employeeNotificationService)
        {
            this.employeeNotificationService = employeeNotificationService;
        }

        private IEmployeeNotificationService employeeNotificationService { get; set; }

        [HttpGet]
        [Route("EmployeeNotification/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.employeeNotificationService.RetrieveById(id, EmployeeNotification.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeNotification>();
        }

        [HttpPost]
        [Route("EmployeeNotification/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.employeeNotificationService.RetrieveAll(EmployeeNotification.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EmployeeNotification>();
        }
            

        
        [HttpPost]
        [Route("EmployeeNotification/Save")]
        public async Task<IActionResult> Save([FromBody] EmployeeNotification employeeNotification)
        {
            var result = await this.employeeNotificationService.Save(employeeNotification, this.UserCredit);

			return result.ToActionResult<EmployeeNotification>();
        }

        
        [HttpPost]
        [Route("EmployeeNotification/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EmployeeNotification employeeNotification)
        {
            var result = await this.employeeNotificationService.SaveAttached(employeeNotification, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeNotification/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EmployeeNotification> employeeNotificationList)
        {
            var result = await this.employeeNotificationService.SaveBulk(employeeNotificationList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeNotification/Seek")]
        public async Task<IActionResult> Seek([FromBody] EmployeeNotification employeeNotification)
        {
            var result = await this.employeeNotificationService.Seek(employeeNotification, this.UserCredit);

			return result.ToActionResult<EmployeeNotification>();
        }

        [HttpGet]
        [Route("EmployeeNotification/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.employeeNotificationService.SeekByValue(seekValue, EmployeeNotification.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeNotification>();
        }

        [HttpPost]
        [Route("EmployeeNotification/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeNotification employeeNotification)
        {
            var result = await this.employeeNotificationService.Delete(employeeNotification, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}