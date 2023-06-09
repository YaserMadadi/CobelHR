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
    public class CoachingQuestionaryController : BaseController
    {
        public CoachingQuestionaryController(ICoachingQuestionaryService coachingQuestionaryService)
        {
            this.coachingQuestionaryService = coachingQuestionaryService;
        }

        private ICoachingQuestionaryService coachingQuestionaryService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionary/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachingQuestionaryService.RetrieveById(id, CoachingQuestionary.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionary>();
        }

        [HttpPost]
        [Route("CoachingQuestionary/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachingQuestionaryService.RetrieveAll(CoachingQuestionary.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CoachingQuestionary>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionary/Save")]
        public async Task<IActionResult> Save([FromBody] CoachingQuestionary coachingQuestionary)
        {
            var result = await this.coachingQuestionaryService.Save(coachingQuestionary, this.UserCredit);

			return result.ToActionResult<CoachingQuestionary>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionary/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CoachingQuestionary coachingQuestionary)
        {
            var result = await this.coachingQuestionaryService.SaveAttached(coachingQuestionary, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionary/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CoachingQuestionary> coachingQuestionaryList)
        {
            var result = await this.coachingQuestionaryService.SaveBulk(coachingQuestionaryList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionary/Seek")]
        public async Task<IActionResult> Seek([FromBody] CoachingQuestionary coachingQuestionary)
        {
            var result = await this.coachingQuestionaryService.Seek(coachingQuestionary, this.UserCredit);

			return result.ToActionResult<CoachingQuestionary>();
        }

        [HttpGet]
        [Route("CoachingQuestionary/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachingQuestionaryService.SeekByValue(seekValue, CoachingQuestionary.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionary>();
        }

        [HttpPost]
        [Route("CoachingQuestionary/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionary coachingQuestionary)
        {
            var result = await this.coachingQuestionaryService.Delete(coachingQuestionary, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCoachingQuestionaryAnswered
        [HttpPost]
        [Route("CoachingQuestionary/{coachingQuestionary_id:int}/CoachingQuestionaryAnswered")]
        public IActionResult CollectionOfCoachingQuestionaryAnswered([FromRoute(Name = "coachingQuestionary_id")] int id, CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            return this.coachingQuestionaryService.CollectionOfCoachingQuestionaryAnswered(id, coachingQuestionaryAnswered, this.UserCredit).ToActionResult();
        }

		// CollectionOfCoachingQuestionaryDetail
        [HttpPost]
        [Route("CoachingQuestionary/{coachingQuestionary_id:int}/CoachingQuestionaryDetail")]
        public IActionResult CollectionOfCoachingQuestionaryDetail([FromRoute(Name = "coachingQuestionary_id")] int id, CoachingQuestionaryDetail coachingQuestionaryDetail)
        {
            return this.coachingQuestionaryService.CollectionOfCoachingQuestionaryDetail(id, coachingQuestionaryDetail, this.UserCredit).ToActionResult();
        }
    }
}