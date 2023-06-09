using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class YearQuarterController : BaseController
    {
        public YearQuarterController(IYearQuarterService yearQuarterService)
        {
            this.yearQuarterService = yearQuarterService;
        }

        private IYearQuarterService yearQuarterService { get; set; }

        [HttpGet]
        [Route("YearQuarter/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.yearQuarterService.RetrieveById(id, YearQuarter.Informer, this.UserCredit);

			return result.ToActionResult<YearQuarter>();
        }

        [HttpPost]
        [Route("YearQuarter/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.yearQuarterService.RetrieveAll(YearQuarter.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<YearQuarter>();
        }
            

        
        [HttpPost]
        [Route("YearQuarter/Save")]
        public async Task<IActionResult> Save([FromBody] YearQuarter yearQuarter)
        {
            var result = await this.yearQuarterService.Save(yearQuarter, this.UserCredit);

			return result.ToActionResult<YearQuarter>();
        }

        
        [HttpPost]
        [Route("YearQuarter/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] YearQuarter yearQuarter)
        {
            var result = await this.yearQuarterService.SaveAttached(yearQuarter, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("YearQuarter/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<YearQuarter> yearQuarterList)
        {
            var result = await this.yearQuarterService.SaveBulk(yearQuarterList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("YearQuarter/Seek")]
        public async Task<IActionResult> Seek([FromBody] YearQuarter yearQuarter)
        {
            var result = await this.yearQuarterService.Seek(yearQuarter, this.UserCredit);

			return result.ToActionResult<YearQuarter>();
        }

        [HttpGet]
        [Route("YearQuarter/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.yearQuarterService.SeekByValue(seekValue, YearQuarter.Informer, this.UserCredit);

			return result.ToActionResult<YearQuarter>();
        }

        [HttpPost]
        [Route("YearQuarter/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] YearQuarter yearQuarter)
        {
            var result = await this.yearQuarterService.Delete(yearQuarter, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessmentTraining_DeadLine
        [HttpPost]
        [Route("DeadLine/{yearQuarter_id:int}/AssessmentTraining")]
        public IActionResult CollectionOfAssessmentTraining_DeadLine([FromRoute(Name = "yearQuarter_id")] int id, AssessmentTraining assessmentTraining)
        {
            return this.yearQuarterService.CollectionOfAssessmentTraining_DeadLine(id, assessmentTraining, this.UserCredit).ToActionResult();
        }
    }
}