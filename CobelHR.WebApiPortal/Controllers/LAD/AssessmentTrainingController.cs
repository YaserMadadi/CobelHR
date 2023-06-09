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
    public class AssessmentTrainingController : BaseController
    {
        public AssessmentTrainingController(IAssessmentTrainingService assessmentTrainingService)
        {
            this.assessmentTrainingService = assessmentTrainingService;
        }

        private IAssessmentTrainingService assessmentTrainingService { get; set; }

        [HttpGet]
        [Route("AssessmentTraining/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.assessmentTrainingService.RetrieveById(id, AssessmentTraining.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentTraining>();
        }

        [HttpPost]
        [Route("AssessmentTraining/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.assessmentTrainingService.RetrieveAll(AssessmentTraining.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<AssessmentTraining>();
        }
            

        
        [HttpPost]
        [Route("AssessmentTraining/Save")]
        public async Task<IActionResult> Save([FromBody] AssessmentTraining assessmentTraining)
        {
            var result = await this.assessmentTrainingService.Save(assessmentTraining, this.UserCredit);

			return result.ToActionResult<AssessmentTraining>();
        }

        
        [HttpPost]
        [Route("AssessmentTraining/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] AssessmentTraining assessmentTraining)
        {
            var result = await this.assessmentTrainingService.SaveAttached(assessmentTraining, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("AssessmentTraining/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<AssessmentTraining> assessmentTrainingList)
        {
            var result = await this.assessmentTrainingService.SaveBulk(assessmentTrainingList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("AssessmentTraining/Seek")]
        public async Task<IActionResult> Seek([FromBody] AssessmentTraining assessmentTraining)
        {
            var result = await this.assessmentTrainingService.Seek(assessmentTraining, this.UserCredit);

			return result.ToActionResult<AssessmentTraining>();
        }

        [HttpGet]
        [Route("AssessmentTraining/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.assessmentTrainingService.SeekByValue(seekValue, AssessmentTraining.Informer, this.UserCredit);

			return result.ToActionResult<AssessmentTraining>();
        }

        [HttpPost]
        [Route("AssessmentTraining/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] AssessmentTraining assessmentTraining)
        {
            var result = await this.assessmentTrainingService.Delete(assessmentTraining, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}