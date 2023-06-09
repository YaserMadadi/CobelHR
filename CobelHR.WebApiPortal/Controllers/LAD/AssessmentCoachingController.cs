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
    public class AssessmentCoachingController : BaseController
    {
        public AssessmentCoachingController(IAssessmentCoachingService assessmentCoachingService)
        {
            this.assessmentCoachingService = assessmentCoachingService;
        }

        private IAssessmentCoachingService assessmentCoachingService { get; set; }

        [HttpGet]
        [Route("AssessmentCoaching/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessmentCoachingService.RetrieveById(id, AssessmentCoaching.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentCoaching>();
        }

        [HttpPost]
        [Route("AssessmentCoaching/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessmentCoachingService.RetrieveAll(AssessmentCoaching.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AssessmentCoaching>();
        }
            

        
        [HttpPost]
        [Route("AssessmentCoaching/Save")]
        public async Task<IActionResult> Save([FromBody] AssessmentCoaching assessmentCoaching)
        {
            var result = await this.assessmentCoachingService.Save(assessmentCoaching, this.UserCredit);

			return result.ToActionResult<AssessmentCoaching>();
        }

        
        [HttpPost]
        [Route("AssessmentCoaching/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AssessmentCoaching assessmentCoaching)
        {
            var result = await this.assessmentCoachingService.SaveAttached(assessmentCoaching, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentCoaching/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AssessmentCoaching> assessmentCoachingList)
        {
            var result = await this.assessmentCoachingService.SaveBulk(assessmentCoachingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentCoaching/Seek")]
        public async Task<IActionResult> Seek([FromBody] AssessmentCoaching assessmentCoaching)
        {
            var result = await this.assessmentCoachingService.Seek(assessmentCoaching, this.UserCredit);

			return result.ToActionResult<AssessmentCoaching>();
        }

        [HttpGet]
        [Route("AssessmentCoaching/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessmentCoachingService.SeekByValue(seekValue, AssessmentCoaching.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentCoaching>();
        }

        [HttpPost]
        [Route("AssessmentCoaching/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentCoaching assessmentCoaching)
        {
            var result = await this.assessmentCoachingService.Delete(assessmentCoaching, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}