using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.HR;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class HoldingSectionController : BaseController
    {
        public HoldingSectionController(IHoldingSectionService holdingSectionService)
        {
            this.holdingSectionService = holdingSectionService;
        }

        private IHoldingSectionService holdingSectionService { get; set; }

        [HttpGet]
        [Route("HoldingSection/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.holdingSectionService.RetrieveById(id, HoldingSection.Informer, this.UserCredit);

			return result.ToActionResult<HoldingSection>();
        }

        [HttpPost]
        [Route("HoldingSection/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.holdingSectionService.RetrieveAll(HoldingSection.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<HoldingSection>();
        }
            

        
        [HttpPost]
        [Route("HoldingSection/Save")]
        public async Task<IActionResult> Save([FromBody] HoldingSection holdingSection)
        {
            var result = await this.holdingSectionService.Save(holdingSection, this.UserCredit);

			return result.ToActionResult<HoldingSection>();
        }

        
        [HttpPost]
        [Route("HoldingSection/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] HoldingSection holdingSection)
        {
            var result = await this.holdingSectionService.SaveAttached(holdingSection, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("HoldingSection/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<HoldingSection> holdingSectionList)
        {
            var result = await this.holdingSectionService.SaveBulk(holdingSectionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("HoldingSection/Seek")]
        public async Task<IActionResult> Seek([FromBody] HoldingSection holdingSection)
        {
            var result = await this.holdingSectionService.Seek(holdingSection, this.UserCredit);

			return result.ToActionResult<HoldingSection>();
        }

        [HttpGet]
        [Route("HoldingSection/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.holdingSectionService.SeekByValue(seekValue, HoldingSection.Informer, this.UserCredit);

			return result.ToActionResult<HoldingSection>();
        }

        [HttpPost]
        [Route("HoldingSection/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] HoldingSection holdingSection)
        {
            var result = await this.holdingSectionService.Delete(holdingSection, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfEmployee_LastHoldingSection
        [HttpPost]
        [Route("LastHoldingSection/{holdingSection_id:int}/Employee")]
        public IActionResult CollectionOfEmployee_LastHoldingSection([FromRoute(Name = "holdingSection_id")] int id, Employee employee)
        {
            return this.holdingSectionService.CollectionOfEmployee_LastHoldingSection(id, employee, this.UserCredit).ToActionResult();
        }

		// CollectionOfEmployeeDetail
        [HttpPost]
        [Route("HoldingSection/{holdingSection_id:int}/EmployeeDetail")]
        public IActionResult CollectionOfEmployeeDetail([FromRoute(Name = "holdingSection_id")] int id, EmployeeDetail employeeDetail)
        {
            return this.holdingSectionService.CollectionOfEmployeeDetail(id, employeeDetail, this.UserCredit).ToActionResult();
        }
    }
}