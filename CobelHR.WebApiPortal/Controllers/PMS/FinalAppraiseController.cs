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
    public class FinalAppraiseController : BaseController
    {
        public FinalAppraiseController(IFinalAppraiseService finalAppraiseService)
        {
            this.finalAppraiseService = finalAppraiseService;
        }

        private IFinalAppraiseService finalAppraiseService { get; set; }

        [HttpGet]
        [Route("FinalAppraise/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.finalAppraiseService.RetrieveById(id, FinalAppraise.Informer, this.UserCredit);

			return result.ToActionResult<FinalAppraise>();
        }

        [HttpPost]
        [Route("FinalAppraise/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.finalAppraiseService.RetrieveAll(FinalAppraise.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<FinalAppraise>();
        }
            

        
        [HttpPost]
        [Route("FinalAppraise/Save")]
        public async Task<IActionResult> Save([FromBody] FinalAppraise finalAppraise)
        {
            var result = await this.finalAppraiseService.Save(finalAppraise, this.UserCredit);

			return result.ToActionResult<FinalAppraise>();
        }

        
        [HttpPost]
        [Route("FinalAppraise/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] FinalAppraise finalAppraise)
        {
            var result = await this.finalAppraiseService.SaveAttached(finalAppraise, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("FinalAppraise/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<FinalAppraise> finalAppraiseList)
        {
            var result = await this.finalAppraiseService.SaveBulk(finalAppraiseList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("FinalAppraise/Seek")]
        public async Task<IActionResult> Seek([FromBody] FinalAppraise finalAppraise)
        {
            var result = await this.finalAppraiseService.Seek(finalAppraise, this.UserCredit);

			return result.ToActionResult<FinalAppraise>();
        }

        [HttpGet]
        [Route("FinalAppraise/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.finalAppraiseService.SeekByValue(seekValue, FinalAppraise.Informer, this.UserCredit);

			return result.ToActionResult<FinalAppraise>();
        }

        [HttpPost]
        [Route("FinalAppraise/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] FinalAppraise finalAppraise)
        {
            var result = await this.finalAppraiseService.Delete(finalAppraise, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}