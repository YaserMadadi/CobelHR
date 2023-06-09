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
    public class CoachingController : BaseController
    {
        public CoachingController(ICoachingService coachingService)
        {
            this.coachingService = coachingService;
        }

        private ICoachingService coachingService { get; set; }

        [HttpGet]
        [Route("Coaching/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachingService.RetrieveById(id, Coaching.Informer, this.UserCredit);

			return result.ToActionResult<Coaching>();
        }

        [HttpPost]
        [Route("Coaching/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachingService.RetrieveAll(Coaching.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Coaching>();
        }
            

        
        [HttpPost]
        [Route("Coaching/Save")]
        public async Task<IActionResult> Save([FromBody] Coaching coaching)
        {
            var result = await this.coachingService.Save(coaching, this.UserCredit);

			return result.ToActionResult<Coaching>();
        }

        
        [HttpPost]
        [Route("Coaching/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Coaching coaching)
        {
            var result = await this.coachingService.SaveAttached(coaching, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Coaching/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Coaching> coachingList)
        {
            var result = await this.coachingService.SaveBulk(coachingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Coaching/Seek")]
        public async Task<IActionResult> Seek([FromBody] Coaching coaching)
        {
            var result = await this.coachingService.Seek(coaching, this.UserCredit);

			return result.ToActionResult<Coaching>();
        }

        [HttpGet]
        [Route("Coaching/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachingService.SeekByValue(seekValue, Coaching.Informer, this.UserCredit);

			return result.ToActionResult<Coaching>();
        }

        [HttpPost]
        [Route("Coaching/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Coaching coaching)
        {
            var result = await this.coachingService.Delete(coaching, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfAssessmentCoaching
        [HttpPost]
        [Route("Coaching/{coaching_id:int}/AssessmentCoaching")]
        public IActionResult CollectionOfAssessmentCoaching([FromRoute(Name = "coaching_id")] int id, AssessmentCoaching assessmentCoaching)
        {
            return this.coachingService.CollectionOfAssessmentCoaching(id, assessmentCoaching, this.UserCredit).ToActionResult();
        }

		// CollectionOfCoachingSession
        [HttpPost]
        [Route("Coaching/{coaching_id:int}/CoachingSession")]
        public IActionResult CollectionOfCoachingSession([FromRoute(Name = "coaching_id")] int id, CoachingSession coachingSession)
        {
            return this.coachingService.CollectionOfCoachingSession(id, coachingSession, this.UserCredit).ToActionResult();
        }
    }
}