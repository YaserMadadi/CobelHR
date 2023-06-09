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
    public class RotationAssessmentController : BaseController
    {
        public RotationAssessmentController(IRotationAssessmentService rotationAssessmentService)
        {
            this.rotationAssessmentService = rotationAssessmentService;
        }

        private IRotationAssessmentService rotationAssessmentService { get; set; }

        [HttpGet]
        [Route("RotationAssessment/RetrieveById/{id:int}")]
        public async Task<IActionResult> RetrieveById(int id)
        {
            var result = await this.rotationAssessmentService.RetrieveById(id, RotationAssessment.Informer, this.UserCredit);

			return result.ToActionResult<RotationAssessment>();
        }

        [HttpPost]
        [Route("RotationAssessment/RetrieveAll/{currentPage:int}")]
        public async Task<IActionResult> RetrieveAll(int currentPage)
        {
            var result = await this.rotationAssessmentService.RetrieveAll(RotationAssessment.Informer, currentPage, this.UserCredit);

			return result.ToActionResult<RotationAssessment>();
        }
            

        
        [HttpPost]
        [Route("RotationAssessment/Save")]
        public async Task<IActionResult> Save([FromBody] RotationAssessment rotationAssessment)
        {
            var result = await this.rotationAssessmentService.Save(rotationAssessment, this.UserCredit);

			return result.ToActionResult<RotationAssessment>();
        }

        
        [HttpPost]
        [Route("RotationAssessment/SaveAttached")]
        public async Task<IActionResult> SaveAttached([FromBody] RotationAssessment rotationAssessment)
        {
            var result = await this.rotationAssessmentService.SaveAttached(rotationAssessment, this.UserCredit);

			return result.ToActionResult();
        }

        
        [HttpPost]
        [Route("RotationAssessment/SaveBulk")]
        public async Task<IActionResult> SaveBulk([FromBody] IList<RotationAssessment> rotationAssessmentList)
        {
            var result = await this.rotationAssessmentService.SaveBulk(rotationAssessmentList, this.UserCredit);

			return result.ToActionResult();
        }

        [HttpPost]
        [Route("RotationAssessment/Seek")]
        public async Task<IActionResult> Seek([FromBody] RotationAssessment rotationAssessment)
        {
            var result = await this.rotationAssessmentService.Seek(rotationAssessment, this.UserCredit);

			return result.ToActionResult<RotationAssessment>();
        }

        [HttpGet]
        [Route("RotationAssessment/SeekByValue/{seekValue}")]
        public async Task<IActionResult> SeekByValue([FromRoute(Name = "seekValue")] string seekValue)
        {
            var result = await this.rotationAssessmentService.SeekByValue(seekValue, RotationAssessment.Informer, this.UserCredit);

			return result.ToActionResult<RotationAssessment>();
        }

        [HttpPost]
        [Route("RotationAssessment/Delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id, [FromBody] RotationAssessment rotationAssessment)
        {
            var result = await this.rotationAssessmentService.Delete(rotationAssessment, id, this.UserCredit);

			return result.ToActionResult();
        }

        
    }
}