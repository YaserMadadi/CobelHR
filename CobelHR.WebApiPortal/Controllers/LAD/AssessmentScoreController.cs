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
    public class AssessmentScoreController : BaseController
    {
        public AssessmentScoreController(IAssessmentScoreService assessmentScoreService)
        {
            this.assessmentScoreService = assessmentScoreService;
        }

        private IAssessmentScoreService assessmentScoreService { get; set; }

        [HttpGet]
        [Route("AssessmentScore/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessmentScoreService.RetrieveById(id, AssessmentScore.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentScore>();
        }

        [HttpPost]
        [Route("AssessmentScore/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessmentScoreService.RetrieveAll(AssessmentScore.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AssessmentScore>();
        }
            

        
        [HttpPost]
        [Route("AssessmentScore/Save")]
        public async Task<IActionResult> Save([FromBody] AssessmentScore assessmentScore)
        {
            var result = await this.assessmentScoreService.Save(assessmentScore, this.UserCredit);

			return result.ToActionResult<AssessmentScore>();
        }

        
        [HttpPost]
        [Route("AssessmentScore/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AssessmentScore assessmentScore)
        {
            var result = await this.assessmentScoreService.SaveAttached(assessmentScore, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentScore/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AssessmentScore> assessmentScoreList)
        {
            var result = await this.assessmentScoreService.SaveBulk(assessmentScoreList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentScore/Seek")]
        public async Task<IActionResult> Seek([FromBody] AssessmentScore assessmentScore)
        {
            var result = await this.assessmentScoreService.Seek(assessmentScore, this.UserCredit);

			return result.ToActionResult<AssessmentScore>();
        }

        [HttpGet]
        [Route("AssessmentScore/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessmentScoreService.SeekByValue(seekValue, AssessmentScore.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentScore>();
        }

        [HttpPost]
        [Route("AssessmentScore/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentScore assessmentScore)
        {
            var result = await this.assessmentScoreService.Delete(assessmentScore, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}