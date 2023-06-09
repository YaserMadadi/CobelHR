using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class QuarterController : BaseController
    {
        public QuarterController(IQuarterService quarterService)
        {
            this.quarterService = quarterService;
        }

        private IQuarterService quarterService { get; set; }

        [HttpGet]
        [Route("Quarter/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.quarterService.RetrieveById(id, Quarter.Informer, this.UserCredit);

			return result.ToActionResult<Quarter>();
        }

        [HttpPost]
        [Route("Quarter/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.quarterService.RetrieveAll(Quarter.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Quarter>();
        }
            

        
        [HttpPost]
        [Route("Quarter/Save")]
        public async Task<IActionResult> Save([FromBody] Quarter quarter)
        {
            var result = await this.quarterService.Save(quarter, this.UserCredit);

			return result.ToActionResult<Quarter>();
        }

        
        [HttpPost]
        [Route("Quarter/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Quarter quarter)
        {
            var result = await this.quarterService.SaveAttached(quarter, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Quarter/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Quarter> quarterList)
        {
            var result = await this.quarterService.SaveBulk(quarterList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Quarter/Seek")]
        public async Task<IActionResult> Seek([FromBody] Quarter quarter)
        {
            var result = await this.quarterService.Seek(quarter, this.UserCredit);

			return result.ToActionResult<Quarter>();
        }

        [HttpGet]
        [Route("Quarter/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.quarterService.SeekByValue(seekValue, Quarter.Informer, this.UserCredit);

			return result.ToActionResult<Quarter>();
        }

        [HttpPost]
        [Route("Quarter/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Quarter quarter)
        {
            var result = await this.quarterService.Delete(quarter, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfYearQuarter
        [HttpPost]
        [Route("Quarter/{quarter_id:int}/YearQuarter")]
        public IActionResult CollectionOfYearQuarter([FromRoute(Name = "quarter_id")] int id, YearQuarter yearQuarter)
        {
            return this.quarterService.CollectionOfYearQuarter(id, yearQuarter, this.UserCredit).ToActionResult();
        }
    }
}