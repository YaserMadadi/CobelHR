using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EssentialCore.Controllers;
using EssentialCore.Tools.Pagination;
using EssentialCore.Tools.Result;
using CobelHR.Services.LAD.Abstract;
using CobelHR.Entities.LAD;

using System.Threading.Tasks;

namespace CobelHR.ApiServices.Controllers.LAD
{
    [Route("api/LAD")]
    public class PromotionResultController : BaseController
    {
        public PromotionResultController(IPromotionResultService promotionResultService)
        {
            this.promotionResultService = promotionResultService;
        }

        private IPromotionResultService promotionResultService { get; set; }

        [HttpGet]
        [Route("PromotionResult/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.promotionResultService.RetrieveById(id, PromotionResult.Informer, this.UserCredit);

			return result.ToActionResult<PromotionResult>();
        }

        [HttpPost]
        [Route("PromotionResult/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.promotionResultService.RetrieveAll(PromotionResult.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PromotionResult>();
        }
            

        
        [HttpPost]
        [Route("PromotionResult/Save")]
        public async Task<IActionResult> Save([FromBody] PromotionResult promotionResult)
        {
            var result = await this.promotionResultService.Save(promotionResult, this.UserCredit);

			return result.ToActionResult<PromotionResult>();
        }

        
        [HttpPost]
        [Route("PromotionResult/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PromotionResult promotionResult)
        {
            var result = await this.promotionResultService.SaveAttached(promotionResult, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PromotionResult/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PromotionResult> promotionResultList)
        {
            var result = await this.promotionResultService.SaveBulk(promotionResultList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PromotionResult/Seek")]
        public async Task<IActionResult> Seek([FromBody] PromotionResult promotionResult)
        {
            var result = await this.promotionResultService.Seek(promotionResult, this.UserCredit);

			return result.ToActionResult<PromotionResult>();
        }

        [HttpGet]
        [Route("PromotionResult/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.promotionResultService.SeekByValue(seekValue, PromotionResult.Informer, this.UserCredit);

			return result.ToActionResult<PromotionResult>();
        }

        [HttpPost]
        [Route("PromotionResult/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PromotionResult promotionResult)
        {
            var result = await this.promotionResultService.Delete(promotionResult, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfPromotionAssessment
        [HttpPost]
        [Route("PromotionResult/{promotionResult_id:int}/PromotionAssessment")]
        public IActionResult CollectionOfPromotionAssessment([FromRoute(Name = "promotionResult_id")] int id, PromotionAssessment promotionAssessment)
        {
            return this.promotionResultService.CollectionOfPromotionAssessment(id, promotionAssessment, this.UserCredit).ToActionResult();
        }
    }
}