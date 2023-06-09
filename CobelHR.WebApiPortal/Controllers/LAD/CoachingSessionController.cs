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
    public class CoachingSessionController : BaseController
    {
        public CoachingSessionController(ICoachingSessionService coachingSessionService)
        {
            this.coachingSessionService = coachingSessionService;
        }

        private ICoachingSessionService coachingSessionService { get; set; }

        [HttpGet]
        [Route("CoachingSession/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachingSessionService.RetrieveById(id, CoachingSession.Informer, this.UserCredit);

			return result.ToActionResult<CoachingSession>();
        }

        [HttpPost]
        [Route("CoachingSession/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachingSessionService.RetrieveAll(CoachingSession.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<CoachingSession>();
        }
            

        
        [HttpPost]
        [Route("CoachingSession/Save")]
        public async Task<IActionResult> Save([FromBody] CoachingSession coachingSession)
        {
            var result = await this.coachingSessionService.Save(coachingSession, this.UserCredit);

			return result.ToActionResult<CoachingSession>();
        }

        
        [HttpPost]
        [Route("CoachingSession/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] CoachingSession coachingSession)
        {
            var result = await this.coachingSessionService.SaveAttached(coachingSession, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("CoachingSession/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<CoachingSession> coachingSessionList)
        {
            var result = await this.coachingSessionService.SaveBulk(coachingSessionList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("CoachingSession/Seek")]
        public async Task<IActionResult> Seek([FromBody] CoachingSession coachingSession)
        {
            var result = await this.coachingSessionService.Seek(coachingSession, this.UserCredit);

			return result.ToActionResult<CoachingSession>();
        }

        [HttpGet]
        [Route("CoachingSession/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachingSessionService.SeekByValue(seekValue, CoachingSession.Informer, this.UserCredit);

			return result.ToActionResult<CoachingSession>();
        }

        [HttpPost]
        [Route("CoachingSession/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] CoachingSession coachingSession)
        {
            var result = await this.coachingSessionService.Delete(coachingSession, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}