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
    public class CoachingQuestionaryDetailController : BaseController
    {
        public CoachingQuestionaryDetailController(ICoachingQuestionaryDetailService coachingQuestionaryDetailService)
        {
            this.coachingQuestionaryDetailService = coachingQuestionaryDetailService;
        }

        private ICoachingQuestionaryDetailService coachingQuestionaryDetailService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionaryDetail/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachingQuestionaryDetailService.RetrieveById(id, CoachingQuestionaryDetail.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachingQuestionaryDetailService.RetrieveAll(CoachingQuestionaryDetail.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryDetail>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/Save")]
        public async Task<IActionResult> Save([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            var result = await this.coachingQuestionaryDetailService.Save(coachingQuestionaryDetail, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryDetail>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            var result = await this.coachingQuestionaryDetailService.SaveAttached(coachingQuestionaryDetail, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryDetail/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CoachingQuestionaryDetail> coachingQuestionaryDetailList)
        {
            var result = await this.coachingQuestionaryDetailService.SaveBulk(coachingQuestionaryDetailList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/Seek")]
        public async Task<IActionResult> Seek([FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            var result = await this.coachingQuestionaryDetailService.Seek(coachingQuestionaryDetail, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpGet]
        [Route("CoachingQuestionaryDetail/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachingQuestionaryDetailService.SeekByValue(seekValue, CoachingQuestionaryDetail.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryDetail>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryDetail/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            var result = await this.coachingQuestionaryDetailService.Delete(coachingQuestionaryDetail, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}