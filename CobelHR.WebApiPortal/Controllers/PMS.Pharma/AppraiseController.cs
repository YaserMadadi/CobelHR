using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.PMS.Pharma.Abstract;
using CobelHR.Entities.PMS.Pharma;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.PMS.Pharma
{
    [Route("api/PMS.Pharma")]
    public class AppraiseController : BaseController
    {
        public AppraiseController(IAppraiseService appraiseService)
        {
            this.appraiseService = appraiseService;
        }

        private IAppraiseService appraiseService { get; set; }

        [HttpGet]
        [Route("Appraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.appraiseService.RetrieveById(id, Appraise.Informer, this.UserCredit);

			return result.ToActionResult<Appraise>();
        }

        [HttpPost]
        [Route("Appraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.appraiseService.RetrieveAll(Appraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Appraise>();
        }
            

        
        [HttpPost]
        [Route("Appraise/Save")]
        public async Task<IActionResult> Save([FromBody] Appraise appraise)
        {
            var result = await this.appraiseService.Save(appraise, this.UserCredit);

			return result.ToActionResult<Appraise>();
        }

        
        [HttpPost]
        [Route("Appraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Appraise appraise)
        {
            var result = await this.appraiseService.SaveAttached(appraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Appraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Appraise> appraiseList)
        {
            var result = await this.appraiseService.SaveBulk(appraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Appraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] Appraise appraise)
        {
            var result = await this.appraiseService.Seek(appraise, this.UserCredit);

			return result.ToActionResult<Appraise>();
        }

        [HttpGet]
        [Route("Appraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.appraiseService.SeekByValue(seekValue, Appraise.Informer, this.UserCredit);

			return result.ToActionResult<Appraise>();
        }

        [HttpPost]
        [Route("Appraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Appraise appraise)
        {
            var result = await this.appraiseService.Delete(appraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}