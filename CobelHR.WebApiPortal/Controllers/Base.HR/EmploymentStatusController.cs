using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.HR.Abstract;
using CobelHR.Entities.Base.HR;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base.HR
{
    [Route("api/Base.HR")]
    public class EmploymentStatusController : BaseController
    {
        public EmploymentStatusController(IEmploymentStatusService employmentStatusService)
        {
            this.employmentStatusService = employmentStatusService;
        }

        private IEmploymentStatusService employmentStatusService { get; set; }

        [HttpGet]
        [Route("EmploymentStatus/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.employmentStatusService.RetrieveById(id, EmploymentStatus.Informer, this.UserCredit);

			return result.ToActionResult<EmploymentStatus>();
        }

        [HttpPost]
        [Route("EmploymentStatus/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.employmentStatusService.RetrieveAll(EmploymentStatus.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EmploymentStatus>();
        }
            

        
        [HttpPost]
        [Route("EmploymentStatus/Save")]
        public async Task<IActionResult> Save([FromBody] EmploymentStatus employmentStatus)
        {
            var result = await this.employmentStatusService.Save(employmentStatus, this.UserCredit);

			return result.ToActionResult<EmploymentStatus>();
        }

        
        [HttpPost]
        [Route("EmploymentStatus/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EmploymentStatus employmentStatus)
        {
            var result = await this.employmentStatusService.SaveAttached(employmentStatus, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EmploymentStatus/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EmploymentStatus> employmentStatusList)
        {
            var result = await this.employmentStatusService.SaveBulk(employmentStatusList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EmploymentStatus/Seek")]
        public async Task<IActionResult> Seek([FromBody] EmploymentStatus employmentStatus)
        {
            var result = await this.employmentStatusService.Seek(employmentStatus, this.UserCredit);

			return result.ToActionResult<EmploymentStatus>();
        }

        [HttpGet]
        [Route("EmploymentStatus/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.employmentStatusService.SeekByValue(seekValue, EmploymentStatus.Informer, this.UserCredit);

			return result.ToActionResult<EmploymentStatus>();
        }

        [HttpPost]
        [Route("EmploymentStatus/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EmploymentStatus employmentStatus)
        {
            var result = await this.employmentStatusService.Delete(employmentStatus, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfEmployee
        [HttpPost]
        [Route("EmploymentStatus/{employmentStatus_id:int}/Employee")]
        public IActionResult CollectionOfEmployee([FromRoute(Name = "employmentStatus_id")] int id, Employee employee)
        {
            return this.employmentStatusService.CollectionOfEmployee(id, employee, this.UserCredit).ToActionResult();
        }

		// CollectionOfEmployeeDetail
        [HttpPost]
        [Route("EmploymentStatus/{employmentStatus_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "employmentStatus_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.employmentStatusService.CollectionOfEmployeeDetail(id, employeeDetail, this.UserCredit).ToActionResult();
        }
    }
}