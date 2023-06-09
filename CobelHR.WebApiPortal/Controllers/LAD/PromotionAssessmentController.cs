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
    public class PromotionAssessmentController : BaseController
    {
        public PromotionAssessmentController(IPromotionAssessmentService promotionAssessmentService)
        {
            this.promotionAssessmentService = promotionAssessmentService;
        }

        private IPromotionAssessmentService promotionAssessmentService { get; set; }

        [HttpGet]
        [Route("PromotionAssessment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.promotionAssessmentService.RetrieveById(id, PromotionAssessment.Informer, this.UserCredit);

			return result.ToActionResult<PromotionAssessment>();
        }

        [HttpPost]
        [Route("PromotionAssessment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.promotionAssessmentService.RetrieveAll(PromotionAssessment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<PromotionAssessment>();
        }
            

        
        [HttpPost]
        [Route("PromotionAssessment/Save")]
        public async Task<IActionResult> Save([FromBody] PromotionAssessment promotionAssessment)
        {
            var result = await this.promotionAssessmentService.Save(promotionAssessment, this.UserCredit);

			return result.ToActionResult<PromotionAssessment>();
        }

        
        [HttpPost]
        [Route("PromotionAssessment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] PromotionAssessment promotionAssessment)
        {
            var result = await this.promotionAssessmentService.SaveAttached(promotionAssessment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("PromotionAssessment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<PromotionAssessment> promotionAssessmentList)
        {
            var result = await this.promotionAssessmentService.SaveBulk(promotionAssessmentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("PromotionAssessment/Seek")]
        public async Task<IActionResult> Seek([FromBody] PromotionAssessment promotionAssessment)
        {
            var result = await this.promotionAssessmentService.Seek(promotionAssessment, this.UserCredit);

			return result.ToActionResult<PromotionAssessment>();
        }

        [HttpGet]
        [Route("PromotionAssessment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.promotionAssessmentService.SeekByValue(seekValue, PromotionAssessment.Informer, this.UserCredit);

			return result.ToActionResult<PromotionAssessment>();
        }

        [HttpPost]
        [Route("PromotionAssessment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] PromotionAssessment promotionAssessment)
        {
            var result = await this.promotionAssessmentService.Delete(promotionAssessment, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}