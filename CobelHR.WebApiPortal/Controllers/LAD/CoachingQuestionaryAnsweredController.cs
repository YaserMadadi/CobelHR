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
    public class CoachingQuestionaryAnsweredController : BaseController
    {
        public CoachingQuestionaryAnsweredController(ICoachingQuestionaryAnsweredService coachingQuestionaryAnsweredService)
        {
            this.coachingQuestionaryAnsweredService = coachingQuestionaryAnsweredService;
        }

        private ICoachingQuestionaryAnsweredService coachingQuestionaryAnsweredService { get; set; }

        [HttpGet]
        [Route("CoachingQuestionaryAnswered/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachingQuestionaryAnsweredService.RetrieveById(id, CoachingQuestionaryAnswered.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachingQuestionaryAnsweredService.RetrieveAll(CoachingQuestionaryAnswered.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryAnswered>();
        }
            

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Save")]
        public async Task<IActionResult> Save([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            var result = await this.coachingQuestionaryAnsweredService.Save(coachingQuestionaryAnswered, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryAnswered>();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            var result = await this.coachingQuestionaryAnsweredService.SaveAttached(coachingQuestionaryAnswered, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingQuestionaryAnswered/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CoachingQuestionaryAnswered> coachingQuestionaryAnsweredList)
        {
            var result = await this.coachingQuestionaryAnsweredService.SaveBulk(coachingQuestionaryAnsweredList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Seek")]
        public async Task<IActionResult> Seek([FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            var result = await this.coachingQuestionaryAnsweredService.Seek(coachingQuestionaryAnswered, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpGet]
        [Route("CoachingQuestionaryAnswered/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachingQuestionaryAnsweredService.SeekByValue(seekValue, CoachingQuestionaryAnswered.Informer, this.UserCredit);

			return result.ToActionResult<CoachingQuestionaryAnswered>();
        }

        [HttpPost]
        [Route("CoachingQuestionaryAnswered/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingQuestionaryAnswered coachingQuestionaryAnswered)
        {
            var result = await this.coachingQuestionaryAnsweredService.Delete(coachingQuestionaryAnswered, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}