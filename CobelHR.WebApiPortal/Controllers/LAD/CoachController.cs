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
    public class CoachController : BaseController
    {
        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        private ICoachService coachService { get; set; }

        [HttpGet]
        [Route("Coach/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.coachService.RetrieveById(id, Coach.Informer, this.UserCredit);

			return result.ToActionResult<Coach>();
        }

        [HttpPost]
        [Route("Coach/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.coachService.RetrieveAll(Coach.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<Coach>();
        }
            

        
        [HttpPost]
        [Route("Coach/Save")]
        public async Task<IActionResult> Save([FromBody] Coach coach)
        {
            var result = await this.coachService.Save(coach, this.UserCredit);

			return result.ToActionResult<Coach>();
        }

        
        [HttpPost]
        [Route("Coach/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] Coach coach)
        {
            var result = await this.coachService.SaveAttached(coach, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("Coach/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<Coach> coachList)
        {
            var result = await this.coachService.SaveBulk(coachList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("Coach/Seek")]
        public async Task<IActionResult> Seek([FromBody] Coach coach)
        {
            var result = await this.coachService.Seek(coach, this.UserCredit);

			return result.ToActionResult<Coach>();
        }

        [HttpGet]
        [Route("Coach/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.coachService.SeekByValue(seekValue, Coach.Informer, this.UserCredit);

			return result.ToActionResult<Coach>();
        }

        [HttpPost]
        [Route("Coach/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] Coach coach)
        {
            var result = await this.coachService.Delete(coach, id, this.UserCredit);

			return result.ToActionResult();
        }

        // CollectionOfCoachConnectionLine
        [HttpPost]
        [Route("Coach/{coach_id:int}/CoachConnectionLine")]
        public IActionResult CollectionOfCoachConnectionLine([FromRoute(Name = "coach_id")] int id, CoachConnectionLine coachConnectionLine)
        {
            return this.coachService.CollectionOfCoachConnectionLine(id, coachConnectionLine, this.UserCredit).ToActionResult();
        }

		// CollectionOfCoaching
        [HttpPost]
        [Route("Coach/{coach_id:int}/Coaching")]
        public IActionResult CollectionOfCoaching([FromRoute(Name = "coach_id")] int id, Coaching coaching)
        {
            return this.coachService.CollectionOfCoaching(id, coaching, this.UserCredit).ToActionResult();
        }
    }
}