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
    public class EmployeeDetailController : BaseController
    {
        public EmployeeDetailController(IEmployeeDetailService employeeDetailService)
        {
            this.employeeDetailService = employeeDetailService;
        }

        private IEmployeeDetailService employeeDetailService { get; set; }

        [HttpGet]
        [Route("EmployeeDetail/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.employeeDetailService.RetrieveById(id, EmployeeDetail.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeDetail>();
        }

        [HttpPost]
        [Route("EmployeeDetail/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.employeeDetailService.RetrieveAll(EmployeeDetail.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<EmployeeDetail>();
        }
            

        
        [HttpPost]
        [Route("EmployeeDetail/Save")]
        public async Task<IActionResult> Save([FromBody] EmployeeDetail employeeDetail)
        {
            var result = await this.employeeDetailService.Save(employeeDetail, this.UserCredit);

			return result.ToActionResult<EmployeeDetail>();
        }

        
        [HttpPost]
        [Route("EmployeeDetail/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] EmployeeDetail employeeDetail)
        {
            var result = await this.employeeDetailService.SaveAttached(employeeDetail, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("EmployeeDetail/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<EmployeeDetail> employeeDetailList)
        {
            var result = await this.employeeDetailService.SaveBulk(employeeDetailList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("EmployeeDetail/Seek")]
        public async Task<IActionResult> Seek([FromBody] EmployeeDetail employeeDetail)
        {
            var result = await this.employeeDetailService.Seek(employeeDetail, this.UserCredit);

			return result.ToActionResult<EmployeeDetail>();
        }

        [HttpGet]
        [Route("EmployeeDetail/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.employeeDetailService.SeekByValue(seekValue, EmployeeDetail.Informer, this.UserCredit);

			return result.ToActionResult<EmployeeDetail>();
        }

        [HttpPost]
        [Route("EmployeeDetail/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] EmployeeDetail employeeDetail)
        {
            var result = await this.employeeDetailService.Delete(employeeDetail, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}