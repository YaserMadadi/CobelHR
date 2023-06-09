using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.Base.Abstract;
using CobelHR.Entities.Base;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.Base
{
    [Route("api/Base")]
    public class YearController : BaseController
    {
        public YearController(IYearService yearService)
        {
            this.yearService = yearService;
        }

        private IYearService yearService { get; set; }

        [HttpGet]
        [Route("Year/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.yearService.RetrieveById(id, Year.Informer, this.UserCredit);

			return result.ToActionResult<Year>();
        }

        [HttpPost]
        [Route("Year/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.yearService.RetrieveAll(Year.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Year>();
        }
            

        
        [HttpPost]
        [Route("Year/Save")]
        public async Task<IActionResult> Save([FromBody] Year year)
        {
            var result = await this.yearService.Save(year, this.UserCredit);

			return result.ToActionResult<Year>();
        }

        
        [HttpPost]
        [Route("Year/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Year year)
        {
            var result = await this.yearService.SaveAttached(year, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Year/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Year> yearList)
        {
            var result = await this.yearService.SaveBulk(yearList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Year/Seek")]
        public async Task<IActionResult> Seek([FromBody] Year year)
        {
            var result = await this.yearService.Seek(year, this.UserCredit);

			return result.ToActionResult<Year>();
        }

        [HttpGet]
        [Route("Year/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.yearService.SeekByValue(seekValue, Year.Informer, this.UserCredit);

			return result.ToActionResult<Year>();
        }

        [HttpPost]
        [Route("Year/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Year year)
        {
            var result = await this.yearService.Delete(year, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfTargetSetting
        [HttpPost]
        [Route("Year/{year_id:int}/TargetSetting")]
        public IActionResult CollectionOfTargetSetting([FromRoute(Name = "year_id")] int id, TargetSetting targetSetting)
        {
            return this.yearService.CollectionOfTargetSetting(id, targetSetting, this.UserCredit).ToActionResult();
        }

		// CollectionOfYearQuarter
        [HttpPost]
        [Route("Year/{year_id:int}/YearQuarter")]
        public IActionResult CollectionOfYearQuarter([FromRoute(Name = "year_id")] int id, YearQuarter yearQuarter)
        {
            return this.yearService.CollectionOfYearQuarter(id, yearQuarter, this.UserCredit).ToActionResult();
        }
    }
}