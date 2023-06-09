using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Abstract;
using CobelHR.Entities.PMS;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS
{
    [Route("api/PMS")]
    public class AppraiseResultController : BaseController
    {
        public AppraiseResultController(IAppraiseResultService appraiseResultService)
        {
            this.appraiseResultService = appraiseResultService;
        }

        private IAppraiseResultService appraiseResultService { get; set; }

        [HttpGet]
        [Route("AppraiseResult/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.appraiseResultService.RetrieveById(id, AppraiseResult.Informer, this.UserCredit);

			return result.ToActionResult<AppraiseResult>();
        }

        [HttpPost]
        [Route("AppraiseResult/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.appraiseResultService.RetrieveAll(AppraiseResult.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AppraiseResult>();
        }
            

        
        [HttpPost]
        [Route("AppraiseResult/Save")]
        public async Task<IActionResult> Save([FromBody] AppraiseResult appraiseResult)
        {
            var result = await this.appraiseResultService.Save(appraiseResult, this.UserCredit);

			return result.ToActionResult<AppraiseResult>();
        }

        
        [HttpPost]
        [Route("AppraiseResult/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AppraiseResult appraiseResult)
        {
            var result = await this.appraiseResultService.SaveAttached(appraiseResult, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AppraiseResult/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AppraiseResult> appraiseResultList)
        {
            var result = await this.appraiseResultService.SaveBulk(appraiseResultList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AppraiseResult/Seek")]
        public async Task<IActionResult> Seek([FromBody] AppraiseResult appraiseResult)
        {
            var result = await this.appraiseResultService.Seek(appraiseResult, this.UserCredit);

			return result.ToActionResult<AppraiseResult>();
        }

        [HttpGet]
        [Route("AppraiseResult/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.appraiseResultService.SeekByValue(seekValue, AppraiseResult.Informer, this.UserCredit);

			return result.ToActionResult<AppraiseResult>();
        }

        [HttpPost]
        [Route("AppraiseResult/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AppraiseResult appraiseResult)
        {
            var result = await this.appraiseResultService.Delete(appraiseResult, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}